using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;

namespace RosSharp.RosBridgeClient
{
    public class LunarLanderSubscribe : UnitySubscriber<MessageTypes.Geometry.Polygon>
    {
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

        protected override void ReceiveMessage(Polygon message)
        {
            if (message != null)
            {
                
                isMessageReceived = true;
            }
            else
            {
                Debug.Log("No position received");
                isMessageReceived = false;
            }
        }
    }
}
