using Amazon.CDK;
using Amazon.CDK.AWS.CodeCommit;
using Amazon.CDK.AWS.CodePipeline;
using Amazon.CDK.AWS.CodePipeline.Actions;
using Amazon.CDK.Pipelines;

namespace Cdk
{
    public class WorkshopPipelineStack : Stack
    {
        public WorkshopPipelineStack(Constructs.Construct scope = null, string id = null, IStackProps props = null) : base(scope, id, props)
        {
            var repo = new Repository(this, "WorkshopRepo", new RepositoryProps{
                RepositoryName = "WorkshopRepo"
            });

            var sourceArtifact = new Artifact_();
            var cloudAssemblyArtifact = new Artifact_();

            var pipeline = new CdkPipeline(this, "Pipeline", new CdkPipelineProps{
                PipelineName = "WorkshopPipeline", 
                CloudAssemblyArtifact = cloudAssemblyArtifact,
                SourceAction = new CodeCommitSourceAction(new CodeCommitSourceActionProps{
                    ActionName = "CodeCommit", 
                    Output = sourceArtifact,
                    Repository = repo
                }),
                SynthAction = SimpleSynthAction.StandardNpmSynth(new StandardNpmSynthOptions{
                    SourceArtifact = sourceArtifact,
                    CloudAssemblyArtifact = cloudAssemblyArtifact,
                    InstallCommand = "npm install -g aws-cdk && apt-get install -y dotnet-sdk-3.1",
                    BuildCommand = "dotnet build"
                })
            });

            // var deploy = new Stage(this, "Deploy");
            // var deployStage = pipeline.AddApplicationStage(deploy);
        }
    }
}