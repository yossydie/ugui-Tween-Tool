using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace uGUI {
	public class uTweenAlpha : uTweenValue {

		private Text mText;
		private Light mLight;
		private Material mMat;
		private Image mImage;
        private RawImage mRawImage;
		private SpriteRenderer mSpriteRender;

        private bool mCached = false;

        public bool includeChildren;

        private Text[] mTexts;
        private Light[] mLights;
        private Image[] mImages;
        private RawImage[] mRawImages;
        private SpriteRenderer[] mSpriteRenders;
        private Renderer[] mRenderers;
        private Dictionary<int, Color> orgColorDic = new Dictionary<int, Color> ();
        private float childValue = 0f;
        private bool mCachedChildren = false;

		void Cache() {
            if (includeChildren == false) {
                mCached = true;

                mText = GetComponent<Text> ();
                if (mText != null) { return; }
                mLight = light;
                if (mLight != null) { return; }
                mImage = GetComponent<Image> ();
                if (mImage != null) { return; }
                mRawImage = GetComponent<RawImage> ();
                if (mRawImage != null) { return; }
                mSpriteRender = GetComponent<SpriteRenderer> ();
                if (mSpriteRender != null) { return; }
                if (renderer != null) {
                    mMat = renderer.material;
                }
                if (mMat != null) { return; }

            } else {
                mCachedChildren = true;

                mTexts = GetComponentsInChildren<Text> ();
                mLights = GetComponentsInChildren<Light> ();
                mImages = GetComponentsInChildren<Image> ();
                mRawImages = GetComponentsInChildren<RawImage> ();
                mSpriteRenders = GetComponentsInChildren<SpriteRenderer> ();
                mRenderers = GetComponentsInChildren<Renderer> ();
            }
		}

		public float alpha {
			get {
                if (includeChildren == false) {
                    if (!mCached) Cache ();
                    if (mText != null) return mText.color.a;
                    if (mLight != null) return mLight.color.a;
                    if (mImage != null) return mImage.color.a;
                    if (mRawImage != null) return mRawImage.color.a;
                    if (mSpriteRender != null) return mSpriteRender.color.a;
                    if (mMat != null) return mMat.color.a;

                } else {
                    if (!mCachedChildren) Cache ();
                    return childValue;
                }
                return Color.white.a;
			}
			set {
                Color c = Color.white;

                if (includeChildren == false) {
                    if (!mCached) Cache ();
                    if (mText != null) {
                        c = mText.color;
                        c.a = value;
                        mText.color = c;
                    }
                    if (mLight != null) {
                        c = mLight.color;
                        c.a = value;
                        mLight.color = c;
                    }
                    if (mImage != null) {
                        c = mImage.color;
                        c.a = value;
                        mImage.color = c;
                    }
                    if (mRawImage != null) {
                        c = mRawImage.color;
                        c.a = value;
                        mRawImage.color = c;
                    }
                    if (mSpriteRender != null) {
                        c = mSpriteRender.color;
                        c.a = value;
                        mSpriteRender.color = c;
                    }
                    if (mMat != null) {
                        c = mMat.color;
                        c.a = value;
                        mMat.color = c;
                    }

                } else {
                    if (!mCachedChildren) Cache ();

                    childValue = value;

                    if (mTexts != null) {
                        foreach (var item in mTexts) {
                            int key = item.gameObject.GetInstanceID();
                            if (orgColorDic.ContainsKey(key) == false) {
                                orgColorDic[key] = item.color;
                            }
                            c = item.color;
                            c.a = value * orgColorDic[key].a;
                            item.color = c;
	                    }
                    }
                    if (mLights != null) {
                        foreach (var item in mLights) {
                            int key = item.gameObject.GetInstanceID ();
                            if (orgColorDic.ContainsKey (key) == false) {
                                orgColorDic[key] = item.color;
                            }
                            c = item.color;
                            c.a = value * orgColorDic[key].a;
                            item.color = c;
	                    }
                    }
                    if (mImages != null) {
                        foreach (var item in mImages) {
                            int key = item.gameObject.GetInstanceID ();
                            if (orgColorDic.ContainsKey (key) == false) {
                                orgColorDic[key] = item.color;
                            }
                            c = item.color;
                            c.a = value * orgColorDic[key].a;
                            item.color = c;
	                    }
                    }
                    if (mRawImages != null) {
                        foreach (var item in mRawImages) {
                            int key = item.gameObject.GetInstanceID ();
                            if (orgColorDic.ContainsKey (key) == false) {
                                orgColorDic[key] = item.color;
                            }
                            c = item.color;
                            c.a = value * orgColorDic[key].a;
                            item.color = c;
                        }
                    }
                    if (mSpriteRenders != null) {
                        foreach (var item in mSpriteRenders) {
                            int key = item.gameObject.GetInstanceID ();
                            if (orgColorDic.ContainsKey (key) == false) {
                                orgColorDic[key] = item.color;
                            }
                            c = item.color;
                            c.a = value * orgColorDic[key].a;
                            item.color = c;
	                    }
                    }
                    if (mRenderers != null) {
                        foreach (var item in mRenderers) {
                            int key = item.gameObject.GetInstanceID ();
                            if (orgColorDic.ContainsKey (key) == false) {
                                orgColorDic[key] = item.material.color;
                            }
                            c = item.material.color;
                            c.a = value * orgColorDic[key].a;
                            item.material.color = c;
	                    }
                    }
                }
			}
		}

		protected override void ValueUpdate (float value, bool isFinished)
		{
			alpha = value;
		}

	}

}