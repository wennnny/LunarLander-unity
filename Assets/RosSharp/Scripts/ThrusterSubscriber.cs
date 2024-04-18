using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class ThrusterSubscriber : UnitySubscriber<MessageTypes.Std.Int32>
    {
        public int isThrusting;
        private bool isMessageReceived;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        void ProcessMessage()
        {
            if (isThrusting == 1)
            {
                Debug.Log("Thrusting");
            }
            else
            {
                Debug.Log("Not thrusting");
            }
            isMessageReceived = false;
        }

        protected override void ReceiveMessage(Int32 message)
        {
            isThrusting = message.data;
            isMessageReceived = true;
        }
    }
}