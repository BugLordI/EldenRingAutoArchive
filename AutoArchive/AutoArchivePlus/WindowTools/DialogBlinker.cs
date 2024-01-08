using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace AutoArchivePlus.WindowTools
{
    internal static class DialogBlinker
    {
        static Storyboard blinkStoryboard;
        static DropShadowEffect dropShadowEffect;
        static Effect originalEffect;
        static Window targetWindow;

        static DialogBlinker()
        {
            blinkStoryboard = InitBlinkStory();
            dropShadowEffect = InitDropShadowEffect();
            blinkStoryboard.Completed += blinkStoryboard_Completed;
        }


        static void blinkStoryboard_Completed(object sender, EventArgs e)
        {
            targetWindow.Effect = originalEffect;
            blinkStoryboard.Completed -= blinkStoryboard_Completed;
        }

        public static void Blink(this Window window)
        {
            if (null != window)
            {
                targetWindow = window;
                if (null == NameScope.GetNameScope(window))
                    NameScope.SetNameScope(window, new NameScope());
                originalEffect = window.Effect;
                if (null == window.Effect || window.Effect.GetType() != typeof(DropShadowEffect))
                    window.Effect = dropShadowEffect;
                window.RegisterName("_blink_effect", window.Effect);
                Storyboard.SetTargetName(blinkStoryboard.Children[0], "_blink_effect");
                //targetWindow.FlashWindowEx();
                blinkStoryboard.Begin(window, true);
                window.UnregisterName("_blink_effect");
            }
        }

        private static Storyboard InitBlinkStory()
        {
            Storyboard storyboard = new Storyboard();
            DoubleAnimationUsingKeyFrames keyFrames = new DoubleAnimationUsingKeyFrames();
            EasingDoubleKeyFrame kt1 = new EasingDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
            EasingDoubleKeyFrame kt2 = new EasingDoubleKeyFrame(8, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.3)));
            kt1.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };
            kt2.EasingFunction = new ElasticEase() { EasingMode = EasingMode.EaseOut };
            keyFrames.KeyFrames.Add(kt1);
            keyFrames.KeyFrames.Add(kt2);
            storyboard.Children.Add(keyFrames);
            Storyboard.SetTargetProperty(keyFrames, new PropertyPath(System.Windows.Media.Effects.DropShadowEffect.BlurRadiusProperty));
            return storyboard;
        }

        private static DropShadowEffect InitDropShadowEffect()
        {
            DropShadowEffect dropShadowEffect = new DropShadowEffect();
            dropShadowEffect.BlurRadius = 8;
            dropShadowEffect.ShadowDepth = 0;
            dropShadowEffect.Direction = 0;
            dropShadowEffect.Color = System.Windows.Media.Colors.Black;
            return dropShadowEffect;
        }

    }
}
