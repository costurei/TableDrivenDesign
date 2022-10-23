namespace System.ComponentModel;

public static class EntityInfoExtensions
{
    public static bool IsNew(this Entity model)
    {
        return model.Id == 0;
    }

    public static bool IsEdit(this Entity model)
    {
        return model.Id != 0;
    }

    public static string GetTypeName(this Entity model)
    {
        var dataEntityType = model.GetType();

        return dataEntityType.Name;
    }

    public static string GetTypeName(this IEnumerable<Entity> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        return dataEntityType.Name;
    }

    public static EntityInfoAttribute GetInfo(this Entity model)
    {
        var dataEntityType = model.GetType();

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(EntityInfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (EntityInfoAttribute)dataInfoAttributes[0];

        return info;
    }

    public static EntityInfoAttribute GetInfo(this IEnumerable<Entity> model)
    {
        var dataEntityType = model.GetType().GetGenericArguments()[0];

        if (dataEntityType == null)
        {
            throw new Exception();
        }

        var dataInfoAttributes = dataEntityType.GetCustomAttributes(typeof(EntityInfoAttribute), false);

        if (dataInfoAttributes.Length == 0)
        {
            throw new Exception();
        }

        var info = (EntityInfoAttribute)dataInfoAttributes[0];

        return info;
    }
}