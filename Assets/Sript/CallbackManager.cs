using System;

namespace Common
{
    public class CallbackManager
    {
        public bool isExecute_ = false;
        private float endTime_ = 0.0f;
        private float elapsedTime_ = 0.0f;
        private Action<float> action_ = null;
        private Action endCallback_ = null;

        public CallbackManager(float endTime, Action<float> action, Action endCallback)
        {
            endTime_ = endTime;
            action_ = action;
            endCallback_ = endCallback;
        }

        public void Start()
        {
            isExecute_ = true;
            elapsedTime_ = 0.0f;
        }

        public void Update(float deltaTime)
        {
            if (isExecute_)
            {
                if (elapsedTime_ <= endTime_)
                {
                    elapsedTime_ += deltaTime;
                    action_?.Invoke(deltaTime);
                }
                else
                {
                    isExecute_ = false;
                    endCallback_?.Invoke();
                }
            }
        }
    }
}
