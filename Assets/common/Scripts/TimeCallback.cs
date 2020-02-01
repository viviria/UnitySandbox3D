﻿using System;
using UnityEngine;

namespace Common
{
    public class TimeCallback
    {
        public bool isExecute_ { private set; get; } = false;
        private float endTime_ = 0.0f;
        private float elapsedTime_ = 0.0f;
        private Action<float> action_ = null;
        private Action endCallback_ = null;

        public TimeCallback(float endTime, Action<float> action, Action endCallback)
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

        public void Update()
        {
            if (isExecute_)
            {
                if (elapsedTime_ <= endTime_)
                {
                    elapsedTime_ += Time.deltaTime;
                    action_?.Invoke(Time.deltaTime);
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
