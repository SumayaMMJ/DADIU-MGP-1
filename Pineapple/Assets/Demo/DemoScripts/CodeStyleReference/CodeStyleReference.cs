using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we put code in namespaces because of scalabillity, naming conflicts and better compile times when the project grows large (Assembly definitions)
namespace Pineapple
{
    /// <summary>
    /// I can put a summary here, it helps other devs understand what the class does! and intellisense will pick it up!
    /// </summary>
    public class CodeStyleReference : MonoBehaviour, ICodeStyleInterface
    {
        // The order of these regions are important, it makes it easier for other devs to navigate new code!!
        // Becomes really important as the codebase grows large!!

        #region Public / Serialized variables
        public int myPublicInteger;

        [SerializeField] string mySerializedString;

        // put name where Something happend is should be descriptive - eg. OnButtonClickDelegate
        public delegate void OnSomethingHappendDelegate(string arg);
        // Again somethingHappend is replaced by buttonClickedDelegate
        public OnSomethingHappendDelegate somethingHappendDelegate;

        // prefix enums with E please 
        public enum EDamageTypes { None, Fire, Frost, Pineapple };
        public EDamageTypes damageTypes = EDamageTypes.Pineapple;
        #endregion

        #region Properties
        // property private variable starts with _!
        private int _myProperty;
        // starts with a capital letter - properties always does this!
        public int MyProperty { get { return _myProperty; } set { _myProperty = value; } }
        #endregion

        #region Protected / Private variables
        protected int myProtectedInt;
        private int myPrivateInt;
        #endregion

        #region Unity Messages
        private void Awake()
        {

        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        private void OnDestroy()
        {

        }
        #endregion

        #region Interface implementations / Public Methods

        // interface implementations comes first
        public void PressedPineappleDown()
        {
            throw new PineappleException();
        }

        public void PressedPineappleUpdate()
        {
            throw new PineappleException();
        }

        public void PressedPineaplleUp()
        {
            throw new PineappleException();
        }

        // Then Standard public methods!

        /// <summary>
        /// When putting summaries you help other developers understand what your code does! 
        /// And what to put in the arguments!
        /// </summary>
        /// <param name="arg">This is the argument description</param>
        public void MyPublicMethod(string arg)
        {

        }
        #endregion

        #region Protected / Private Mehtods

        protected void MyProtectedMethod()
        {
        }

        private void MyPrivateMethod()
        {
        }

        #endregion
    }

    #region Additional Classes / Structs 
    // At the very bottom we put additional classes strcuts etc. 
    class MyHelperClass 
    {
        
    }

    struct MyDataStructure
    {
        public int myInt;
    }
    #endregion
}