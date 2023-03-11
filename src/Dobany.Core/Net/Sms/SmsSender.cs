using System.Threading.Tasks;
using Abp.Dependency;
using Castle.Core.Logging;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using System;

namespace Dobany.Net.Sms
{
    public class SmsSender : ISmsSender, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public SmsSender()
        {
            Logger = NullLogger.Instance;
        }

        public Task SendAsync1(string number, string message)
        {
            /* Implement this service to send SMS to users (can be used for two factor auth). */

            Logger.Warn("Sending SMS is not implemented! Message content:");
            Logger.Warn("Number  : " + number);
            Logger.Warn("Message : " + message);

            return Task.FromResult(0);
        }
        public Task SendAsync(string number, string message)
        {
            //message = "1234";
            String product = "Dysmsapi"; //短信API产品名称   
            String domain = "dysmsapi.aliyuncs.com"; //短信API产品域名  
            String accessKeyId = "LTAI4GKkz7Z3gNV1RSxfC7rd"; //你的accessKeyId  
            String accessKeySecret = "3t4SweYmi1KlL14OPAx7G0tcq1A8Qz"; //你的accessKeySecret  

            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);  
            // SingleSendSmsRequest request = new SingleSendSmsRequest();  

            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;
            //request.AddQueryParameters("PhoneNumbers", "+17783229630");
            var phoneNum = number;
            if (phoneNum.StartsWith("+86"))
            {
                //国内模板
                request.AddQueryParameters("TemplateCode", "SMS_212345093");
                phoneNum = phoneNum.Replace("+86", "");
                Logger.Warn("China");
            }
            else
            {
                //港澳台模板
                request.AddQueryParameters("TemplateCode", "SMS_199773293");
                Logger.Warn("Not China");
            }

            request.AddQueryParameters("PhoneNumbers", phoneNum);
            //request.AddQueryParameters("SignName", "1233232");
            request.AddQueryParameters("SignName", "营口浩宇贸易有限公司");

            //request.AddQueryParameters("TemplateParam", string.Format(@"{""code"":""{0}""}", input.Code));
            request.AddQueryParameters("TemplateParam", "{\"code\":\"" + message + "\"}");
            try

            {
                CommonResponse response = client.GetCommonResponse(request);
                //SaveLog(input, source, "SendSMSVerification", ip, "Success");
                Logger.Warn("OKKKKKKK");

                //return Ok(response.Data);
            }
            catch (Exception e)
            {
                //SaveLog(input, source, "SendSMSVerification", ip, e.Message);
                //return Ok(e.Message);
                Logger.Warn(e.ToString());
            }

            Logger.Warn("Sending SMS is not implemented! Message content:");
            Logger.Warn("Number  : " + number);
            Logger.Warn("Message : " + message);

            return Task.FromResult(0);
        }
       
    }
}
