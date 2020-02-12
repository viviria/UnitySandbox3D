using System;
using UnityEngine;

namespace Common
{
    public class TimeCallback
    {
        public bool isExecute_ { private set; get; } = false;
        private float endTime_ = 0.0f;
        private float elapsedTime_ = 0.0f;
        private Action<float, float> updateAction_ = null;
        private Action endCallback_ = null;

        public TimeCallback(float endTime, Action<float, float> updateAction, Action endCallback)
        {
            endTime_ = endTime;
            updateAction_ = updateAction;
            endCallback_ = endCallback;
        }

        public void Start()
        {
            isExecute_ = true;
            elapsedTime_ = 0.0f;
        }

        public void Update()
        {
            if (isExecute_)
            {
                if (elapsedTime_ <= endTime_)
                {
                    elapsedTime_ += Time.deltaTime;
                    updateAction_?.Invoke(Time.deltaTime, elapsedTime_);
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
