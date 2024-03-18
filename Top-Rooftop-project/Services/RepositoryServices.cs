
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Top_Rooftop_project.Database;

namespace Top_Rooftop_project.Services;

public class RepositoryServices<TEntity, IModel> : IRepositoryServices<TEntity, IModel> where TEntity : class, new() where IModel : class
{
	private readonly IMapper mapper;
	private readonly ApplicationDbContext context;

	public RepositoryServices(IMapper mapper, ApplicationDbContext context)
	{
		this.mapper = mapper;
		this.context = context;
		_dbSet=context.Set<TEntity>();
	}

	private DbSet<TEntity> _dbSet { get; }

	public async Task<IModel> DeltedASync(int id, CancellationToken cancellationToken)
	{
		var entiy = await _dbSet.FindAsync(id);
		if (entiy == null) return null;
		context.Remove(entiy);
		await context.SaveChangesAsync(cancellationToken);
		var deltedModel = mapper.Map<TEntity, IModel>(entiy);
		return deltedModel;
	}

	public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
	{
		var enity = await _dbSet.ToListAsync(cancellationToken);
		if (enity == null) return null;
		var getallAsysnModle = mapper.Map<IEnumerable<IModel>>(enity);
		return getallAsysnModle;

	}

	public async Task<IModel> GetByIdAsync(int id, CancellationToken cancellationToken)
	{
		var entitys = await _dbSet.FindAsync(id);
		if (entitys == null) return null;
		var getByIdModel = mapper.Map<TEntity, IModel>(entitys);
		return getByIdModel;
	}

	public async Task<IModel> InsertAsync(int id, IModel model, CancellationToken cancellationToken)
	{
		var entitys = mapper.Map<IModel, TEntity>(model);
		context.Add(entitys);
		await context.SaveChangesAsync(cancellationToken);
		var insertModel = mapper.Map<TEntity, IModel>(entitys);
		return insertModel;
	}

	public async Task<IModel> UpdatedAsync(int id, IModel model, CancellationToken cancellationToken)
	{
		var entitys = await _dbSet.FindAsync(id);
		if (entitys == null) return null;
		mapper.Map(model, entitys);
		await context.SaveChangesAsync(cancellationToken);
		var updatedModle = mapper.Map<TEntity, IModel>(entitys);
		return updatedModle;
	}
}
