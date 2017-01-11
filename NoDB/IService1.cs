using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NoDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "Login/{username}/{password}", ResponseFormat = WebMessageFormat.Json)]
        Boolean Login(string username, string password);

        [OperationContract]
        [WebGet(UriTemplate = "Send/{username}/{password}/{message}", ResponseFormat = WebMessageFormat.Json)]
        void Send(string username, string password, string message);

        [OperationContract]
        [WebGet(UriTemplate = "Messages/{username}/{password}", ResponseFormat = WebMessageFormat.Json)]
        string[] Messages(string username, string password);

        [OperationContract]
        [WebGet(UriTemplate = "Messages/{username}/{password}/{id}", ResponseFormat = WebMessageFormat.Json)]
        string[] Messagesid(string username, string password, string id);

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
