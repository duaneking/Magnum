// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Specs.Activator.Classes
{
	using System;

	public class ClassWithGuidConstraint :
		ConstrainedBy<Guid>
	{
		public ClassWithGuidConstraint(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; private set; }

		public bool Equals(ClassWithGuidConstraint other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id.Equals(Id);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (ClassWithGuidConstraint)) return false;
			return Equals((ClassWithGuidConstraint) obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}