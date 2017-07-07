using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PathService
{
    /// <summary>
    /// Контракт службы должен определить контракт обратного вызова (callback) в свойстве CallbackContract своего атрибута [ServiceContract]
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IMyPathService
    {
        /// <summary>
        /// Прототип метода, который может вызывать клиент. Метод является односторонним (IsOneWay = true), поэтому служба не отправляет ответ клиенту.
        /// Односторонние методы обязаны возвращать тип void.
        /// </summary>
        /// <param name="path"></param>
        [OperationContract(IsOneWay = true)]
        void GetFolderСontents(string path);
    }
    /// <summary>
    /// Контракт обратного вызова - определяет методы, которые служба может вызывать на стороне клиента.
    /// </summary>
    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void GiveFolderContents(string contents);
    }
}
