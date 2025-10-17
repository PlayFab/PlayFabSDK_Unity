using System;
using System.Runtime.InteropServices;
using PlayFab;
using PlayFab.Interop;

namespace PartyCSharpSDK.Interop
{
    //typedef struct PARTY_INITIALIZATION_CONFIGURATION
    //{
    //    PartyString titleId;
    //    XTaskQueueHandle audioTaskQueue;
    //    XTaskQueueHandle networkingTaskQueue;
    //}
    //PARTY_INITIALIZATION_CONFIGURATION;
    [StructLayout(LayoutKind.Sequential)]
    internal struct PARTY_INITIALIZATION_CONFIGURATION
    {
        readonly UTF8StringPtr titleId;
        readonly XTaskQueueHandle audioTaskQueue;
        readonly XTaskQueueHandle networkingTaskQueue;

        internal PARTY_INITIALIZATION_CONFIGURATION(UTF8StringPtr title_id, XTaskQueueHandle audio_task_queue, XTaskQueueHandle networking_task_queue)
        {
            titleId = title_id;
            audioTaskQueue = audio_task_queue;
            networkingTaskQueue = networking_task_queue;
        }

    }

}