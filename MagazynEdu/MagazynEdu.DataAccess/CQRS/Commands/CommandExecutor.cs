namespace MagazynEdu.DataAccess.CQRS
{
    using System.Threading.Tasks;
    using MagazynEdu.DataAccess.CQRS.Commands;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly WarehouseStorageContext context;

        public CommandExecutor(WarehouseStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}