using Amazon.CDK;
using Amazon.CDK.Pipelines;
using Cdk;

namespace CdkWorkshop
{
    public class WorkshopPipelineStage : Stage
    {
        public WorkshopPipelineStage(Construct scope, string id, StageProps props = null)
            : base(scope, id, props)
        {
            var service = new CdkStack(this, "WebService");
        }
    }
}
