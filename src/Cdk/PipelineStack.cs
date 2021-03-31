using Amazon.CDK;
using Amazon.CDK.AWS.CodeCommit;
namespace Cdk
{
    public class WorkshopPipelineStack : Stack
    {
        public WorkshopPipelineStack(Constructs.Construct scope = null, string id = null, IStackProps props = null) : base(scope, id, props)
        {
            var repo = new Repository(this, "WorkshopRepo", new RepositoryProps{
                RepositoryName = "WorkshopRepo"
            });
        }
    }
}