using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

//Self hosting
//VS Admin
//Create Project --> Class Library(.NET Framework) --> LMSServices_Sec1
//Delete the class
//Add new item -> WCF services -- LMSSErvices_Sec1
//ILMSSevices_Sect1 --> string GetMessage(string StudentName);
//Implement this method in the class
//Delete the app.config
//We need to host the LMSServices
//We created a new console application, name HOSTLMSServices
//Refrence of System.ServiceModel, project --> LMSService_Sec1
//Build the solution

namespace LMSServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILMSServices" in both code and config file together.
    [ServiceContract]
    public interface ILMSServices
    {
        [OperationContract]
        string GetMessage(string StudentName);

        [OperationContract]
        string Hello();





        [OperationContract]
        List<Genre> GetAllGenre();

        [OperationContract]
        Genre GetGenre(int id);

        [OperationContract]
        int DeleteGenre(int id);

        [OperationContract]
        int CreateGenre(Genre genrePara);

        [OperationContract]
        int EditGenre(Genre genrePara);





        [OperationContract]
        List<Music> GetAllMusic();

        [OperationContract]
        Music GetMusic(int id);

        [OperationContract]
        int DeleteMusic(int id);

        [OperationContract]
        int CreateMusic(Music musicPara);

        [OperationContract]
        int EditMusic(Music musicPara);


    }
}
