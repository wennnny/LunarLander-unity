using UnityEngine;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;

namespace RosSharp.RosBridgeClient
{
    public class LunarLanderSubscribe : UnitySubscriber<MessageTypes.Geometry.Polygon>
    {
        public float[] position_1;
        public float[] position_2;
        public float[] position_3;
        public float[] position_4;
        public float[] position_5;
        public float[] position_6;
        private bool isMessageReceived;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            position_6  = new float[2]; 

        }

        // Update is called once per frame
        void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        void ProcessMessage()
        {
            if (position_1 != null)
            {
                Debug.Log("Subscribed position: " + position_1 + ", " + position_1);
            }
            else
            {
                Debug.Log("No position received");
                isMessageReceived = false;
            }
        }

        protected override void ReceiveMessage(Polygon message)
        {
            position_1[0] = (float)message.points[0].x;
            position_1[1] = (float)message.points[0].y;
            position_2[0] = (float)message.points[1].x;
            position_2[1] = (float)message.points[1].y;
            position_3[0] = (float)message.points[2].x;
            position_3[1] = (float)message.points[2].y;
            position_4[0] = (float)message.points[3].x;
            position_4[1] = (float)message.points[3].y;
            position_5[0] = (float)message.points[4].x;
            position_5[1] = (float)message.points[4].y;
            position_6[0] = (float)message.points[5].x;
            position_6[1] = (float)message.points[5].y;
            Debug.Log(position_6[0] + ", " + position_6[1]);
            isMessageReceived = true;
        }
    }
}
