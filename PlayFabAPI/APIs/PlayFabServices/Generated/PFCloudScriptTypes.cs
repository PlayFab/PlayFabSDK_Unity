// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// CloudScriptRevisionOption enum.
    /// </summary>
    public enum PFCloudScriptCloudScriptRevisionOption : uint
    {
        Live = Interop.PFCloudScriptCloudScriptRevisionOption.Live,
        Latest = Interop.PFCloudScriptCloudScriptRevisionOption.Latest,
        Specific = Interop.PFCloudScriptCloudScriptRevisionOption.Specific
    }

    /// <summary>
    /// PFCloudScriptExecuteCloudScriptRequest data model.
    /// </summary>
    public struct PFCloudScriptExecuteCloudScriptRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The name of the CloudScript function to execute.
        /// </summary>
        public string FunctionName;

        /// <summary>
        /// (Optional) Object that is passed in to the function as the first argument.
        /// </summary>
        public PFJsonObject FunctionParameter;

        /// <summary>
        /// (Optional) Generate a 'player_executed_cloudscript' PlayStream event containing the results of the
        /// function execution and other contextual information. This event will show up in the PlayStream debugger
        /// console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;

        /// <summary>
        /// (Optional) Option for which revision of the CloudScript to execute. 'Latest' executes the most recently
        /// created revision, 'Live' executes the current live, published revision, and 'Specific' executes the
        /// specified revision. The default value is 'Specific', if the SpeificRevision parameter is specified,
        /// otherwise it is 'Live'.
        /// </summary>
        public PFCloudScriptCloudScriptRevisionOption? RevisionSelection;

        /// <summary>
        /// (Optional) The specivic revision to execute, when RevisionSelection is set to 'Specific'.
        /// </summary>
        public int? SpecificRevision;

        internal unsafe static void ToInterop(PFCloudScriptExecuteCloudScriptRequest self, Interop.PFCloudScriptExecuteCloudScriptRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionName, &interop->functionName, buffer);

            if (self.FunctionParameter.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionParameter.stringValue, &interop->functionParameter.stringValue, buffer);
            }

            if (self.GeneratePlayStreamEvent != null)
            {
                *interop->generatePlayStreamEvent = InteropWrapper.WrapperHelpers.BoolToInterop(self.GeneratePlayStreamEvent.Value);
            }

            if (self.RevisionSelection != null)
            {
                *interop->revisionSelection = (Interop.PFCloudScriptCloudScriptRevisionOption)self.RevisionSelection.Value;
            }

            if (self.SpecificRevision != null)
            {
                *interop->specificRevision = self.SpecificRevision.Value;
            }

        }
    }

    /// <summary>
    /// PFCloudScriptScriptExecutionError data model.
    /// </summary>
    public struct PFCloudScriptScriptExecutionError
    {
        /// <summary>
        /// (Optional) Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded,
        /// CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError.
        /// </summary>
        public string? Error;

        /// <summary>
        /// (Optional) Details about the error.
        /// </summary>
        public string? Message;

        /// <summary>
        /// (Optional) Point during the execution of the script at which the error occurred, if any.
        /// </summary>
        public string? StackTrace;

        internal unsafe PFCloudScriptScriptExecutionError(Interop.PFCloudScriptScriptExecutionError interop)
        {

            Error = (interop.error == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.error);

            Message = (interop.message == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.message);

            StackTrace = (interop.stackTrace == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.stackTrace);

        }

        internal unsafe static void ToInterop(PFCloudScriptScriptExecutionError self, Interop.PFCloudScriptScriptExecutionError* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Error != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Error, &interop->error, buffer);
            }

            if (self.Message != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Message, &interop->message, buffer);
            }

            if (self.StackTrace != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StackTrace, &interop->stackTrace, buffer);
            }

        }
    }

    /// <summary>
    /// PFCloudScriptLogStatement data model.
    /// </summary>
    public struct PFCloudScriptLogStatement
    {
        /// <summary>
        /// (Optional) Optional object accompanying the message as contextual information.
        /// </summary>
        public PFJsonObject Data;

        /// <summary>
        /// (Optional) 'Debug', 'Info', or 'Error'.
        /// </summary>
        public string? Level;

        /// <summary>
        /// (Optional) Message property.
        /// </summary>
        public string? Message;

        internal unsafe PFCloudScriptLogStatement(Interop.PFCloudScriptLogStatement interop)
        {

            Data = (interop.data.stringValue == null) ? default : new PFJsonObject(interop.data);

            Level = (interop.level == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.level);

            Message = (interop.message == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.message);

        }

        internal unsafe static void ToInterop(PFCloudScriptLogStatement self, Interop.PFCloudScriptLogStatement* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Data.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Data.stringValue, &interop->data.stringValue, buffer);
            }

            if (self.Level != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Level, &interop->level, buffer);
            }

            if (self.Message != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Message, &interop->message, buffer);
            }

        }
    }

    /// <summary>
    /// PFCloudScriptExecuteCloudScriptResult data model.
    /// </summary>
    public struct PFCloudScriptExecuteCloudScriptResult
    {
        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function.
        /// </summary>
        public int APIRequestsIssued;

        /// <summary>
        /// (Optional) Information about the error, if any, that occurred during execution.
        /// </summary>
        public PFCloudScriptScriptExecutionError? Error;

        /// <summary>
        /// ExecutionTimeSeconds property.
        /// </summary>
        public double ExecutionTimeSeconds;

        /// <summary>
        /// (Optional) The name of the function that executed.
        /// </summary>
        public string? FunctionName;

        /// <summary>
        /// (Optional) The object returned from the CloudScript function, if any.
        /// </summary>
        public PFJsonObject FunctionResult;

        /// <summary>
        /// (Optional) Flag indicating if the FunctionResult was too large and was subsequently dropped from
        /// this event. This only occurs if the total event size is larger than 350KB.
        /// </summary>
        public bool? FunctionResultTooLarge;

        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function.
        /// </summary>
        public int HttpRequestsIssued;

        /// <summary>
        /// (Optional) Entries logged during the function execution. These include both entries logged in the
        /// function code using log.info() and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public PFCloudScriptLogStatement[]? Logs;

        /// <summary>
        /// (Optional) Flag indicating if the logs were too large and were subsequently dropped from this event.
        /// This only occurs if the total event size is larger than 350KB after the FunctionResult was removed.
        /// </summary>
        public bool? LogsTooLarge;

        /// <summary>
        /// MemoryConsumedBytes property.
        /// </summary>
        public uint MemoryConsumedBytes;

        /// <summary>
        /// Processor time consumed while executing the function. This does not include time spent waiting on
        /// API calls or HTTP requests.
        /// </summary>
        public double ProcessorTimeSeconds;

        /// <summary>
        /// The revision of the CloudScript that executed.
        /// </summary>
        public int Revision;

        internal unsafe PFCloudScriptExecuteCloudScriptResult(Interop.PFCloudScriptExecuteCloudScriptResult interop)
        {

            APIRequestsIssued = interop.aPIRequestsIssued;

            Error = (interop.error == null) ? null : new(*interop.error);

            ExecutionTimeSeconds = interop.executionTimeSeconds;

            FunctionName = (interop.functionName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.functionName);

            FunctionResult = (interop.functionResult.stringValue == null) ? default : new PFJsonObject(interop.functionResult);

            FunctionResultTooLarge = (interop.functionResultTooLarge == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.functionResultTooLarge);

            HttpRequestsIssued = interop.httpRequestsIssued;

            Logs = (interop.logs == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.logs, interop.logsCount, elem => new PFCloudScriptLogStatement(elem));

            LogsTooLarge = (interop.logsTooLarge == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.logsTooLarge);

            MemoryConsumedBytes = interop.memoryConsumedBytes;

            ProcessorTimeSeconds = interop.processorTimeSeconds;

            Revision = interop.revision;

        }
    }

    /// <summary>
    /// PFCloudScriptExecuteCloudScriptServerRequest data model.
    /// </summary>
    public struct PFCloudScriptExecuteCloudScriptServerRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The name of the CloudScript function to execute.
        /// </summary>
        public string FunctionName;

        /// <summary>
        /// (Optional) Object that is passed in to the function as the first argument.
        /// </summary>
        public PFJsonObject FunctionParameter;

        /// <summary>
        /// (Optional) Generate a 'player_executed_cloudscript' PlayStream event containing the results of the
        /// function execution and other contextual information. This event will show up in the PlayStream debugger
        /// console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;

        /// <summary>
        /// The unique user identifier for the player on whose behalf the script is being run.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// (Optional) Option for which revision of the CloudScript to execute. 'Latest' executes the most recently
        /// created revision, 'Live' executes the current live, published revision, and 'Specific' executes the
        /// specified revision. The default value is 'Specific', if the SpeificRevision parameter is specified,
        /// otherwise it is 'Live'.
        /// </summary>
        public PFCloudScriptCloudScriptRevisionOption? RevisionSelection;

        /// <summary>
        /// (Optional) The specivic revision to execute, when RevisionSelection is set to 'Specific'.
        /// </summary>
        public int? SpecificRevision;

        internal unsafe static void ToInterop(PFCloudScriptExecuteCloudScriptServerRequest self, Interop.PFCloudScriptExecuteCloudScriptServerRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionName, &interop->functionName, buffer);

            if (self.FunctionParameter.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionParameter.stringValue, &interop->functionParameter.stringValue, buffer);
            }

            if (self.GeneratePlayStreamEvent != null)
            {
                *interop->generatePlayStreamEvent = InteropWrapper.WrapperHelpers.BoolToInterop(self.GeneratePlayStreamEvent.Value);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            if (self.RevisionSelection != null)
            {
                *interop->revisionSelection = (Interop.PFCloudScriptCloudScriptRevisionOption)self.RevisionSelection.Value;
            }

            if (self.SpecificRevision != null)
            {
                *interop->specificRevision = self.SpecificRevision.Value;
            }

        }
    }

    /// <summary>
    /// PFCloudScriptExecuteEntityCloudScriptRequest data model. Executes CloudScript with the entity profile
    /// that is defined in the request.
    /// </summary>
    public struct PFCloudScriptExecuteEntityCloudScriptRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The name of the CloudScript function to execute.
        /// </summary>
        public string FunctionName;

        /// <summary>
        /// (Optional) Object that is passed in to the function as the first argument.
        /// </summary>
        public PFJsonObject FunctionParameter;

        /// <summary>
        /// (Optional) Generate a 'entity_executed_cloudscript' PlayStream event containing the results of the
        /// function execution and other contextual information. This event will show up in the PlayStream debugger
        /// console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;

        /// <summary>
        /// (Optional) Option for which revision of the CloudScript to execute. 'Latest' executes the most recently
        /// created revision, 'Live' executes the current live, published revision, and 'Specific' executes the
        /// specified revision. The default value is 'Specific', if the SpecificRevision parameter is specified,
        /// otherwise it is 'Live'.
        /// </summary>
        public PFCloudScriptCloudScriptRevisionOption? RevisionSelection;

        /// <summary>
        /// (Optional) The specific revision to execute, when RevisionSelection is set to 'Specific'.
        /// </summary>
        public int? SpecificRevision;

        internal unsafe static void ToInterop(PFCloudScriptExecuteEntityCloudScriptRequest self, Interop.PFCloudScriptExecuteEntityCloudScriptRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionName, &interop->functionName, buffer);

            if (self.FunctionParameter.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionParameter.stringValue, &interop->functionParameter.stringValue, buffer);
            }

            if (self.GeneratePlayStreamEvent != null)
            {
                *interop->generatePlayStreamEvent = InteropWrapper.WrapperHelpers.BoolToInterop(self.GeneratePlayStreamEvent.Value);
            }

            if (self.RevisionSelection != null)
            {
                *interop->revisionSelection = (Interop.PFCloudScriptCloudScriptRevisionOption)self.RevisionSelection.Value;
            }

            if (self.SpecificRevision != null)
            {
                *interop->specificRevision = self.SpecificRevision.Value;
            }

        }
    }

    /// <summary>
    /// PFCloudScriptExecuteFunctionRequest data model. Executes an Azure Function with the profile of the
    /// entity that is defined in the request.
    /// </summary>
    public struct PFCloudScriptExecuteFunctionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The name of the CloudScript function to execute.
        /// </summary>
        public string FunctionName;

        /// <summary>
        /// (Optional) Object that is passed in to the function as the FunctionArgument field of the FunctionExecutionContext
        /// data structure.
        /// </summary>
        public PFJsonObject FunctionParameter;

        /// <summary>
        /// (Optional) Generate a 'entity_executed_cloudscript_function' PlayStream event containing the results
        /// of the function execution and other contextual information. This event will show up in the PlayStream
        /// debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;

        internal unsafe static void ToInterop(PFCloudScriptExecuteFunctionRequest self, Interop.PFCloudScriptExecuteFunctionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionName, &interop->functionName, buffer);

            if (self.FunctionParameter.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FunctionParameter.stringValue, &interop->functionParameter.stringValue, buffer);
            }

            if (self.GeneratePlayStreamEvent != null)
            {
                *interop->generatePlayStreamEvent = InteropWrapper.WrapperHelpers.BoolToInterop(self.GeneratePlayStreamEvent.Value);
            }

        }
    }

    /// <summary>
    /// PFCloudScriptFunctionExecutionError data model.
    /// </summary>
    public struct PFCloudScriptFunctionExecutionError
    {
        /// <summary>
        /// (Optional) Error code, such as CloudScriptAzureFunctionsExecutionTimeLimitExceeded, CloudScriptAzureFunctionsArgumentSizeExceeded,
        /// CloudScriptAzureFunctionsReturnSizeExceeded or CloudScriptAzureFunctionsHTTPRequestError.
        /// </summary>
        public string? Error;

        /// <summary>
        /// (Optional) Details about the error.
        /// </summary>
        public string? Message;

        /// <summary>
        /// (Optional) Point during the execution of the function at which the error occurred, if any.
        /// </summary>
        public string? StackTrace;

        internal unsafe PFCloudScriptFunctionExecutionError(Interop.PFCloudScriptFunctionExecutionError interop)
        {

            Error = (interop.error == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.error);

            Message = (interop.message == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.message);

            StackTrace = (interop.stackTrace == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.stackTrace);

        }

        internal unsafe static void ToInterop(PFCloudScriptFunctionExecutionError self, Interop.PFCloudScriptFunctionExecutionError* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Error != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Error, &interop->error, buffer);
            }

            if (self.Message != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Message, &interop->message, buffer);
            }

            if (self.StackTrace != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StackTrace, &interop->stackTrace, buffer);
            }

        }
    }

    /// <summary>
    /// PFCloudScriptExecuteFunctionResult data model.
    /// </summary>
    public struct PFCloudScriptExecuteFunctionResult
    {
        /// <summary>
        /// (Optional) Error from the CloudScript Azure Function.
        /// </summary>
        public PFCloudScriptFunctionExecutionError? Error;

        /// <summary>
        /// The amount of time the function took to execute.
        /// </summary>
        public int ExecutionTimeMilliseconds;

        /// <summary>
        /// (Optional) The name of the function that executed.
        /// </summary>
        public string? FunctionName;

        /// <summary>
        /// (Optional) The object returned from the function, if any.
        /// </summary>
        public PFJsonObject FunctionResult;

        /// <summary>
        /// (Optional) The size in bytes of the object returned from the function, if any.
        /// </summary>
        public int? FunctionResultSize;

        /// <summary>
        /// (Optional) Flag indicating if the FunctionResult was too large and was subsequently dropped from
        /// this event.
        /// </summary>
        public bool? FunctionResultTooLarge;

        internal unsafe PFCloudScriptExecuteFunctionResult(Interop.PFCloudScriptExecuteFunctionResult interop)
        {

            Error = (interop.error == null) ? null : new(*interop.error);

            ExecutionTimeMilliseconds = interop.executionTimeMilliseconds;

            FunctionName = (interop.functionName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.functionName);

            FunctionResult = (interop.functionResult.stringValue == null) ? default : new PFJsonObject(interop.functionResult);

            FunctionResultSize = (interop.functionResultSize == null) ? null : *interop.functionResultSize;

            FunctionResultTooLarge = (interop.functionResultTooLarge == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.functionResultTooLarge);

        }
    }

}
