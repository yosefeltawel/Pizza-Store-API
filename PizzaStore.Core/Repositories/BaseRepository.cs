using PizzaStore.Data.DatabaseSpecific;
using PizzaStore.Data.Linq;

namespace PizzaStore.Core.Repositories;

public abstract class BaseRepository
{
    protected readonly DataAccessAdapter _adapter;
    protected readonly LinqMetaData _meta;

    public BaseRepository(DataAccessAdapter adapter)
    {
        _adapter = adapter;
        _meta = new LinqMetaData(_adapter);
    }
}