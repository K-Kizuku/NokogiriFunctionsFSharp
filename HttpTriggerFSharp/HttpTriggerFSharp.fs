namespace Company.Function

open System
open System.IO
open System.Net
open System.Text.Json.Serialization
open System.Data
open System.Linq
open System.Threading.Tasks
open System.Data.SqlClient
open System.Data.Linq
open System.Data.Linq.Mapping
open System.Data.Linq.SqlClient
open System.Data.SqlTypes
open System.Collections.Generic
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.AspNetCore.Http
open Microsoft.OpenApi.Models
open Newtonsoft.Json
open Microsoft.Extensions.Logging
open Azure
open Azure.Core
open Azure.Data.Tables
open FSharp.Data.SqlClient
open NameAndAid

//���O�Ɖ������Ɋւ���Functions
module ReturnAid =
    //��������Ԃ�
    [<FunctionName("GetPoint")>]
    let GetPointRun ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = "getRoom/{room}")>]req: HttpRequest) ([<Sql("select * from room",
                CommandType = System.Data.CommandType.Text,
                //Parameters = "@Room={Query.room}",
                ConnectionStringSetting = "Server=tcp:unity-streaming.database.windows.net,1433;Initial Catalog=Unitydb;Persist Security Info=False;User ID=Kizuku;Password=Nin/Doudayo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")>]data: IEnumerable<IdAndPoint>) (log: ILogger) =
        async {
            log.LogInformation("Get Function processed a request.")
            

            return OkObjectResult(data) :> IActionResult
        } |> Async.StartAsTask

    [<FunctionName("DeleteData")>]
    let DeleteDataRun ([<HttpTrigger(AuthorizationLevel.Function, "delete", Route = "DeleteFunction")>]req: HttpRequest) ([<Sql("DeleteItem", CommandType = System.Data.CommandType.StoredProcedure, 
                Parameters = "@Id={Query.id}", ConnectionStringSetting = "SqlConnectionString")>]data: IEnumerable<IdAndPoint>) (log: ILogger) =
        async {
            log.LogInformation("Delete Function processed a request")

            return OkObjectResult() :> IActionResult
        } |> Async.StartAsTask

//�z�M�̃��[����A�z�M��ԁA�v���C���[�֌W�̏�ԂɊւ���Functions
module Room =
    //��ӂ�roomId��Ԃ�Function
    [<FunctionName("GetRoomNum")>]
    let GetRoomNumRun([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>]req: HttpRequest) (log: ILogger) =
        async {
            log.LogInformation("Get Room Num processed a request.")

            return OkObjectResult() :>IActionResult
        } |> Async.StartAsTask
    
    //�z�M��Ԃ�true�ɂ���Function
    [<FunctionName("StartStreaming")>]
    let StartStreamingRun([<HttpTrigger(AuthorizationLevel.Function, "post", Route = null)>]req: HttpRequest) (log: ILogger) =
        async {
            log.LogInformation("Get Room Num processed a request.")

            return OkObjectResult() :>IActionResult
        } |> Async.StartAsTask
    
    //�z�M��Ԃ�false�ɂ���Function
    [<FunctionName("StopStreaming")>]
    let StopStreamingRun([<HttpTrigger(AuthorizationLevel.Function, "post", Route = null)>]req: HttpRequest) (log: ILogger) =
        async {
            log.LogInformation("Get Room Num processed a request.")

            return OkObjectResult() :>IActionResult
        } |> Async.StartAsTask

