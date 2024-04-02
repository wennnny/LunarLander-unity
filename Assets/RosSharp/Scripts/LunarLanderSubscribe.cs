using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class LunarLanderSubscribe : UnitySubscriber<MessageTypes.Std.Float32MultiArray>
    {
        public Transform LunarLander;
        private float position;
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
            if (position != null)
            {
                Debug.Log("Subscribeed position:" + position);
            }
            else
            {
                Debug.Log("No position received");
                isMessageReceived = false;
            }
        }

        protected override void ReceiveMessage(Float32MultiArray message)
        {
            position = message.data[0];
            isMessageReceived = true;
        }
    }
}
