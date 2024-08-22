namespace SGE.Application;

public class UpdateStateService(IFileRepository repo, ISpecificationStateChange specification) : IUpdateStateService
{
    public void UpdateState(int id)
    {
        File file = repo.GetById(id)!;
        if (file.Procedures.Count > 0)
        {
            FileState? newState = specification.GetState(file.Procedures.Last().Label);
            if (newState is not null)
            {
                file.State = newState.Value;
                repo.Update(file);
            }
        }
    }
}
