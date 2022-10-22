namespace System.ComponentModel;

public static class TableInfoExtensions
{
    public static bool IsNew(this Table model)
    {
        return model.Id == 0;
    }

    public static bool IsEdit(this Table model)
    {
        return model.Id != 0;
    }

    public static string GetTypeName(this Table model)
    {
        var dataEntityType = model.GetType();

        return dataEntityType.Name;
    }

    public static string GetTypeName(this IEnumerable<Table> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        return dataEntityType.Name;
    }

    public static TableInfoAttribute GetInfo(this Table model)
    {
        var dataEntityType = model.GetType();

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(TableInfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (TableInfoAttribute)dataInfoAttributes[0];

        return info;
    }

    public static TableInfoAttribute GetInfo(this IEnumerable<Table> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(TableInfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (TableInfoAttribute)dataInfoAttributes[0];

        return info;
    }
}