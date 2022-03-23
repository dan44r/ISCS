namespace CF.Web.Security
{
    public interface IPermission
    {
        string Name
        {
            get;
        }

        int PermissionId
        {
            get;
        }
    }
}