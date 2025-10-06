using Godot;
using System;

namespace Components
{
    /// <summary>
    /// This component manages the health of an entity, it only handles health. It throws events when health changes or when the entity dies.
    /// It does not handle audio, visual effects, or any other game logic, only health.
    /// This can be easily changed
    /// </summary>
    public partial class HealthComponent : Node
    {
        /// <summary>
        /// The Maxium health of the entity.
        /// </summary>
        [Export]
        public float MaxHealth { get; private set; } = 100f;
        /// <summary>
        /// The current health of the entity.
        /// </summary>
        [Export]
        public float Health { get; private set; } = 100f;

        public event Action OnHealthChanged;
        public event Action OnMaxHealthChanged;
        public event Action OnDeath;

        public void SetHealth(float newHealth)
        {
            Health = newHealth;
            if (Health <= 0)
            {
                OnDeath?.Invoke();
            }
            OnHealthChanged?.Invoke();
        }
        public void SetMaxHealth(float newMaxHealth, bool healToNewHealth = false)
        {
            MaxHealth = newMaxHealth;
            if (healToNewHealth)
            {
                SetHealth(MaxHealth);
            }
            OnMaxHealthChanged?.Invoke();
        }
        public void Heal(float amount)
        {
            Health += amount;
            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            OnHealthChanged?.Invoke();
        }
        public void Damage(float amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                OnDeath?.Invoke();
            }
            OnHealthChanged?.Invoke();
        }
    }
}
