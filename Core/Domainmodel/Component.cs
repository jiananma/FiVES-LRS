using System;
using System.Collections.Generic;
using System.Diagnostics;
using Events;
using System.Dynamic;

namespace FIVES
{
    public class AttributeTypeMismatchException : System.Exception
    {
        public AttributeTypeMismatchException() : base() { }
        public AttributeTypeMismatchException(string message) : base(message) { }
    }

    public class AttributeIsNotDefinedException : System.Exception
    {
        public AttributeIsNotDefinedException() : base() { }
        public AttributeIsNotDefinedException(string message) : base(message) { }
    }

    public class Component : DynamicObject
    {
        private Guid Id {get; set; }

        public delegate void AttributeChanged (Object sender, AttributeChangedEventArgs e);
        public event AttributeChanged OnAttributeChanged;

        public void subscribeToEvent(AttributeChanged eventHandler)
        {
            this.OnAttributeChanged += eventHandler;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string attributeName = binder.Name;
            if (!attributes.ContainsKey(attributeName)) {
                throw new AttributeIsNotDefinedException(
                    "Attribute '" + attributeName + "' is not defined in the component '" + componentName + "'.");
            }

            result = attributes [attributeName].value;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string attributeName = binder.Name;

            if (checkAttributeExistsAndTypeMatches (attributeName, value.GetType())) {
                this.attributes [attributeName].value = value;
                if (this.OnAttributeChanged != null)
                    this.OnAttributeChanged(this, new AttributeChangedEventArgs(attributeName, value));
                return true;
            } else {
                return false;
            }
        }

        internal Component() {}

        // Can only be constructed by ComponentRegistry.createComponent to ensure correct attributes.
        internal Component (string name)
        {
            componentName = name;
            this.attributes = new Dictionary<string, Attribute> ();
        }

        // This is used to populate the attributes into a component based on it's layout.
        internal void addAttribute(string attributeName, Type type) {
            // If the attribute already exists, then it's an internal error (probably in ComponentRegistry).
            Debug.Assert(!attributes.ContainsKey(attributeName));

            attributes.Add(attributeName, new Attribute(type, null));
        }

        private bool checkAttributeExistsAndTypeMatches(string attributeName, Type requestedType) {
            if (!attributes.ContainsKey(attributeName)) {
                throw new AttributeIsNotDefinedException(
                    "Attribute '" + attributeName + "' is not defined in the component '" + componentName + "'.");
            }

            Type attributeType = attributes[attributeName].type;
            if (attributeType != requestedType) {
                throw new AttributeTypeMismatchException(
                    "Attribute '\" + attributeName + \"' has a different type in the component '" + componentName +
                    "'. Requested type is " + requestedType.ToString() + ", but attribute type is " +
                    attributeType.ToString() + ".");
            }

            return true;
        }

        private IDictionary<string, Attribute> attributes {get ; set;}
        private string componentName;
    }
}
