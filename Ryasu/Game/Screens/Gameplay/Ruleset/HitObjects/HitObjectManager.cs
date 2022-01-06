using Ryasu.API.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ryasu.Game.Screens.Gameplay.Ruleset.HitObjects
{
    public class HitObjectManager
    {
        public List<Queue<GameplayHitObject>> ActiveNoteLanes { get; } = new List<Queue<GameplayHitObject>>();
        public List<Queue<GameplayHitObject>> DeadNoteLanes { get; } = new List<Queue<GameplayHitObject>>();
        public List<Queue<GameplayHitObject>> HeldNoteLanes { get; } = new List<Queue<GameplayHitObject>>();
        public List<Queue<HitObjectInfo>> HitObjects { get; } = new List<Queue<HitObjectInfo>>();

        public HitObjectManager(Rys map)
        {
            //Read all HitObjects
            foreach(var hitObject in map.HitObjects)
            {
                int lane = hitObject.Lane - 1;
                HitObjects[lane].Enqueue(hitObject);
            }

            
        }

        private void CreateReceptors()
        {

        }

        public float GetPositionFromTime(double time)
        {
            /*
            float spritePosition = 0f;

            if (ConfigManager.Downscroll.Value)
                spritePosition = (float)(SkinManager.Skin.JudgementLine - (AudioTrackPosition - time) * -(0.45 * ScrollSpeed));
            else
                spritePosition = (float)(SkinManager.Skin.JudgementLine - (AudioTrackPosition - time) * (0.45 * ScrollSpeed));
            */
            return 0;
        }
    }
}
