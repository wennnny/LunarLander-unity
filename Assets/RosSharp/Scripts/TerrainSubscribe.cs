using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class TerrainSubscribe : UnitySubscriber<MessageTypes.Std.Float32MultiArray>
    {
        public Transform Terrainscale;
        private float scale;
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
            if (scale != null)
            {
                Debug.Log("Subscribeed scale:" + scale);
            }
            else
            {
                Debug.Log("No scale received");
                isMessageReceived = false;
            }
        }

        protected override void ReceiveMessage(Float32MultiArray message)
        {
            scale = message.data[0];
            isMessageReceived = true;
        }
    }
}
