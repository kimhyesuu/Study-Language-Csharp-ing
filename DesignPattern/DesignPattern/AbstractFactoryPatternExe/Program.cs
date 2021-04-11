using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternExe
{
	public class Client
	{
		private Packaging _packaging;
		private DeliveryDocument _deliveryDocument;

		public Client(PacknDelvFactory factory)
		{
			_packaging = factory.CreatePackaging();
			_deliveryDocument = factory.CreateDeliveryDocument();
		}

		public Packaging ClientPackaging
		{
			get { return _packaging; }
		}

		public DeliveryDocument ClientDocument
		{
			get { return _deliveryDocument; }
		}
	}
	public abstract class PacknDelvFactory
	{
		public abstract Packaging CreatePackaging();
		public abstract DeliveryDocument CreateDeliveryDocument();
	}
	public class StandardFactory : PacknDelvFactory
	{
		public override Packaging CreatePackaging()
		{
			return new StandardPackaging();
		}
		public override DeliveryDocument CreateDeliveryDocument()
		{
			return new Postal();
		}
	}
	public class DelicateFactory : PacknDelvFactory
	{
		public override Packaging CreatePackaging()
		{
			return new ShockProofPackaging();
		}
		public override DeliveryDocument CreateDeliveryDocument()
		{
			return new Courier();
		}
	}
	public abstract class Packaging { }
	public class StandardPackaging : Packaging { }
	public class ShockProofPackaging : Packaging { }
	public abstract class DeliveryDocument { }
	public class Postal : DeliveryDocument { }
	public class Courier : DeliveryDocument { }
}
