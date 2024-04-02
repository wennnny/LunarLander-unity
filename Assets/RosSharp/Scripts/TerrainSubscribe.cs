using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class TerrainSubscribe : UnitySubscriber<MessageTypes.Std.Float32MultiArray>
    {
        public float scale_left;
        public float scale_right;
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
            if (scale_left != null && scale_right != null)
            {
                Debug.Log("Subscribeed scale:" + scale_left + " " + scale_right);
            }
            else
            {
                Debug.Log("No scale received");
                isMessageReceived = false;
            }
        }

        protected override void ReceiveMessage(Float32MultiArray message)
        {
            scale_left = message.data[0];
            scale_right = message.data[1];
            isMessageReceived = true;
        }
    }
}
