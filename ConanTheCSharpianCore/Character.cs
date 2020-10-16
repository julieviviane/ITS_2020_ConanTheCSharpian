﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConanTheCSharpian.Core
{
    public abstract class Character
    {
        #region Fields

        /// <summary>
        /// Name of the Character
        /// </summary>
        public string Name { get; protected set; } // We changed it into a property to give public read access and mantain protected write access

        /// <summary>
        /// Base damage inflicted by the Character
        /// </summary>
        protected float Damage;

        /// <summary>
        /// Maximum health available to the Character
        /// </summary>
        protected float MaxHealth;

        /// <summary>
        /// Current health of the Character
        /// </summary>
        private float _currentHealth;

        /// <summary>
        /// Chance of successfully hitting an opponent during an attack
        /// (expressed in a [0, 1] range)
        /// </summary>
        protected float Accuracy;

        /// <summary>
        /// Character controller currently in charge of controlling this character
        /// </summary>
        private ICharacterController _controller;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Current health of the character.
        /// Automatically handles Max Health capping and avoids resurrection
        /// </summary>
        public float CurrentHealth
        {
            // Equivalent to "GetCurrentHealth()"
            get
            {
                return _currentHealth;
            }

            // Equivalent to "SetCurrentHealth(value)"
            protected set
            {
                if (value > MaxHealth)
                    value = MaxHealth;

                if (IsDead)
                    return;

                _currentHealth = value;
            }
        }

        /// <summary>
        /// Get class name for this character
        /// I.E.: "Mage", "Barbarian", "Troll"...
        /// </summary>
        private string Category { get { return GetType().Name; } }

        /// <summary>
        /// Get a fully qualified name for the character, using Name and Category.
        /// I.E.: "Gandalf, the Mage"
        /// </summary>
        public string FullyQualifiedName => $"{Name}, the {Category}"; // even more condensed way of writing get { return ... }

        public bool IsDead
        {
            get
            {
                return _currentHealth <= 0;
            }
        }

        #endregion Properties

        #region Actions

        public void PerformBaseAttack()
        {
            // TODO: I have to implement that
        }

        public abstract void PerformSpecialAction();

        #endregion Actions
    }
}
