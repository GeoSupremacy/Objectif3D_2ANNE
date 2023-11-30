using System;
using UnityEngine;
using UnityEditor;
using EditorUtils.Style;


namespace EditorUtils.Button
{
    public struct AlertBox
    {
        public string Title;
        public string Message;
        public string Ok;
        public string Cancel;
        public AlertBox(string title, string message, string ok, string cancel)
        {
            Title = title;
            Message = message;
            Ok = ok;
            Cancel = cancel;
        }

    }
    public class ButtonUtils
    {
        public static bool MakeButton(string _label, Action _callback)
        { 
            if (GUILayout.Button(_label)) 
            {
                _callback?.Invoke();
                return true;
            }
            return false; 
        }
        public static bool MakeButton(string _label, Action _callback, int _padding)
        {
            GUILayout.Space(_padding);
            if (GUILayout.Button(_label))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, Padding2D _padding)
        {
            GUILayout.Space(_padding.Top);
            if (GUILayout.Button(_label))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, GUIStyle _style)
        {
            if (GUILayout.Button(_label, _style))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, Color _color)
        {
            if (GUILayout.Button(_label, GUIStyleUtils.GetButtonStyle(_color, FontStyle.Bold, 15)))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, GUIStyle _style, int _padding)
        {
            GUILayout.Space(_padding);
            if (GUILayout.Button(_label, _style))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, GUIStyle _style, Padding2D _padding)
        {
            GUILayout.Space(_padding.Top);
            if (GUILayout.Button(_label, _style))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, Color _color, int _padding = 5)
        {
            GUILayout.Space(_padding);  
            if (GUILayout.Button(_label, GUIStyleUtils.GetButtonStyle(_color, FontStyle.Bold, 15)))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, Color _color, FontStyle _fontStyle = FontStyle.Bold, int _fontSize = 15)
        {
            if (GUILayout.Button(_label, GUIStyleUtils.GetButtonStyle(_color,  _fontStyle,  _fontSize)))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeButton(string _label, Action _callback, Color _color, Padding2D _padding)
        {
            GUILayout.Space(_padding.Top);
            if (GUILayout.Button(_label, GUIStyleUtils.GetButtonStyle(_color, FontStyle.Bold, 15)))
            {
                _callback?.Invoke();
                return true;
            }
            return false;
        }
        public static bool MakeInteractButton(bool _isValid, string _label, Action _callback, Color _color, int _padding = 5)
        {
            if (_isValid)
                return MakeButton(_label, _callback,_color,_padding);
            else
            {
                EditorGUILayout.HelpBox("Problem Cube", MessageType.Warning);
                GUILayout.Box(_label);
                return false;
            }
      
        }
        public static bool MakeInteractButton(bool _isValid, string _label, Action _callback, Color _color, int _padding = 5, string _message = "Problem", MessageType _messageType = MessageType.Warning)
        {
            if (_isValid)
                return MakeButton(_label, _callback, _color, _padding);
            else
            {
                EditorGUILayout.HelpBox(_message, _messageType);
                GUILayout.Box(_label);
                return false;
            }

        }
        public static bool MakeInteractButton(bool _isValid,string _label, Action _callback, Color _color, Padding2D _padding, string _message = "Problem", MessageType _messageType = MessageType.Warning)
        {
            if (_isValid)
                return MakeButton(_label, _callback, _color, _padding);
            else
            {
                EditorGUILayout.HelpBox(_message, _messageType);
                GUILayout.Box(_label);
                return false;
            }

        }
        public static bool MakeInteractButtonWithPoppup(bool _isValid, string _label, Action _callback, Color _color, int _padding =5, string _message = "Problem", MessageType _messageType = MessageType.Warning, string _popup ="Popup", string _messagePopup = "Message", string _messageYes = "Yes", string _messageNo = "No")
        {
            if (_isValid)
            {
               
                    return MakeButton(_label, () =>
                    {
                        if (Popup(_popup, _messagePopup, _messageYes, _messageNo))
                            _callback?.Invoke();
                                
                        
                    }, _color, _padding);
               
            }
            else
            {
                EditorGUILayout.HelpBox(_message, _messageType);
                GUILayout.Box(_label);
                return false;
            }

        }
        public static bool MakeInteractButtonWithPoppup(bool _isValid, string _label, Action _callback, Color _color, AlertBox _alertBox, int _padding =5, string _message = "Problem",
            MessageType _messageType = MessageType.Warning)
        {
            if (_isValid)
            {

                return MakeButton(_label, () =>
                {
                    if (EditorUtility.DisplayDialog(_alertBox.Title, _alertBox.Message, _alertBox.Ok, _alertBox.Cancel))
                        _callback?.Invoke();


                }, _color, _padding);

            }
            else
            {
                EditorGUILayout.HelpBox(_message, _messageType);
                GUILayout.Box(_label);
                return false;
            }

        }

        public static bool Popup(string _popup, string _message,string _messageYes ="Yes", string _messageNo = "No")
        {
            return EditorUtility.DisplayDialog(_popup, _message, _messageYes, _messageNo);
             
        }
    }//
}// *

