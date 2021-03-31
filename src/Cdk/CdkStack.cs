using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.SQS;
using Amazon.CDK.AWS.APIGateway;
namespace Cdk
{
    public class CdkStack : Stack
    {
        internal CdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var hello = new Function(this, "Hellohandler", new FunctionProps(){
                Runtime = Runtime.NODEJS_10_X,
                Code = Code.FromAsset("lambda"),
                Handler = "hello.handler"
            });

            new LambdaRestApi(this, "Endpoint", new LambdaRestApiProps{
                Handler = hello
            });
            //  // The CDK includes built-in constructs for most resource types, such as Queues and Topics.
            // var queue = new Queue(this, "CdkQueue", new QueueProps
            // {
            //     VisibilityTimeout = Duration.Seconds(300)
            // });

            // var topic = new Topic(this, "CdkTopic");

            // topic.AddSubscription(new SqsSubscription(queue));
        }
    }
}
