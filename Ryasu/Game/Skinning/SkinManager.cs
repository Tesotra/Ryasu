using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Ryasu.Game.Skinning.Advanced;

namespace Ryasu.Game.Skinning
{
    public static class SkinManager
    {
        public static Skin Skin { get; private set; }
        private static Skin DefaultSkin { get; set; }

        public static void LoadSkin(string path)
        {
            string p = $"{path}/skin.json";

            if(Skin != null)
            {
                if (!Skin.DefaultSkin)
                {
                    Skin.KeyModes.Clear();
                    Skin.HitPositions.Clear();
                    Skin.SkinName = null;
                    Skin.SkinAuthor = null;
                    Skin.WhistleHitSound = null;
                    Skin.FinishHitSound = null;
                    Skin.ClapHitSound = null;
                    Skin.DefaultHitSound = null;
                }
            }

            if (!File.Exists(p))
            {
                Skin = null;
            }
            else
            {
                Skin = JsonConvert.DeserializeObject<Skin>(File.ReadAllText(p));
            }

            if (Skin == null)
            {
                //Load Default Skin
                Skin = LoadDefaultSkin();
                return;
            }
        }

        public static void SaveSkin()
        {
            string json = JsonConvert.SerializeObject(Skin);

            PathableString pathablePath = $"[dir]/Skins/{Skin.SkinName}";
            PathableString pathableJson = $"[dir]/Skins/{Skin.SkinName}/skin.json";

            if (!Directory.Exists(pathablePath.Text))
            {
                Directory.CreateDirectory(pathablePath.Text);
            }

            using(StreamWriter writer = new StreamWriter(pathableJson.Text))
            {
                writer.Flush();
                writer.Write(json);
            }
        }

        private static Skin LoadDefaultSkin()
        {
            if (DefaultSkin != null)
                return DefaultSkin;

            Skin tmp = new Skin();

            tmp.DefaultSkin = true;

            tmp.SkinName = "ryasu!";
            tmp.SkinAuthor = "Tesotra";
            tmp.KeyModes = new List<List<SkinnedLaneTexture>>();
            tmp.HitPositions = new List<int>();

            #region 1 Key
            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });
            #endregion

            #region 2 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 3 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 4 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 5 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 6 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 7 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 8 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 9 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            #region 10 Keys

            tmp.KeyModes.Add(new List<SkinnedLaneTexture>()
            {
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/yellow-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/white-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                },
                new SkinnedLaneTexture()
                {
                     HitObject = "HitObjects/smoothGreen-bar.png",
                     Receptor = "Receptors/default-receptor.png"
                }
            });

            #endregion

            for(int i = 0; i < 10; i++)
            {
                tmp.HitPositions.Add(430);
            }

            tmp.WhistleHitSound = "Samples/Whistle-HitSound.wav";
            tmp.ClapHitSound = "Samples/Clap-HitSound.wav";
            tmp.DefaultHitSound = "Samples/HitSound.wav";
            tmp.FinishHitSound = "Samples/Finish-HitSound.wav";

            DefaultSkin = tmp;

            return tmp;
        }
    }
}
