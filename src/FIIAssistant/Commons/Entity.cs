﻿using System;

namespace Commons {
    public class Entity {
        public Entity() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}