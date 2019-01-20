using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSALVL;

namespace JamBuilder
{

	public struct ObjProperty
	{
		string type, value;
		public ObjProperty(string type, string value = "")
		{
			this.type = type;
			this.value = value;
		}
	}

	public class LevelObject
	{

		public Dictionary<string, ObjProperty> properties = new Dictionary<string, ObjProperty>();
		public UInt32 x, y, wuid;
		public string kind;

		public LevelObject() { }

		//Copy
		public LevelObject(LevelObject src)
		{
			this.x = src.x;
			this.y = src.y;
			this.wuid = src.wuid;
			this.kind = src.kind;
			this.properties = new Dictionary<string, ObjProperty>(src.properties);
		}

	}

	public struct LevelProperties
	{
		public string background, tileset;
		public Stage stageData;
	}

	public class LevelSession
	{
		private uint height, width;
		private LevelProperties levelProperties;
		public enum OBJECT_CATEGORY
		{
			GENERIC,
			ITEMS,
			GS_ITEM,
			BOSS,
			ENEMY
		};
		public enum DECO_CATEGORY
		{
			GENERIC,
			BACK,
			FRONT,
			UNK
		};
		private List<LevelObject> objects = new List<LevelObject>();
		private List<LevelObject> items = new List<LevelObject>();
		private List<LevelObject> gsItems = new List<LevelObject>();
		private List<LevelObject> bosses = new List<LevelObject>();
		private List<LevelObject> enemies = new List<LevelObject>();
		private List<Block> blocks = new List<Block>();
		private List<Collision> collisions = new List<Collision>();
		private List<Decoration> decosBack = new List<Decoration>();
		private List<Decoration> decos = new List<Decoration>();
		private List<Decoration> decosFront = new List<Decoration>();
		private List<Decoration> decosUnk = new List<Decoration>();

		private List<HistoryNode> historyStack = new List<HistoryNode>();
		private uint historyMaxSize = 100;//TODO: Take affect

		public LevelSession()
		{
			//TODO: Loading/Initializing
		}

		//TODO: Implement undo/redo functions
		//TODO: pushHistory function
		//TODO: HistoryNode-Grouping for mass-edits (eg: deleting multiple objects at the same time)

		public int addObj(OBJECT_CATEGORY category, LevelObject obj)
		{
			List<LevelObject> l = getObjList(category);
			l.Add(obj);
			
			historyStack.Add(new HNodeObjAdded(this, obj, l.Count-1, category));
			return l.Count - 1;
		}

		public void removeObj(OBJECT_CATEGORY category, int index)
		{
			List<LevelObject> l = getObjList(category);
			LevelObject obj = l[index];

			l.RemoveAt(index);
			
			historyStack.Add(new HNodeObjRemoved(this, obj, index, category));
		}

		/// <summary>
		/// Replaces a LevelObject
		/// </summary>
		public void updateObj(OBJECT_CATEGORY category, int index, LevelObject newObj)
		{
			List<LevelObject> l = getObjList(category);
			LevelObject old = l[index];
			l[index] = newObj;
			historyStack.Add(new HNodeObjUpdated(this, old, newObj, index, category));
		}

		/// <summary>
		/// Returns a copy
		/// </summary>
		public LevelObject getObj(OBJECT_CATEGORY category, int index)
		{
			return new LevelObject(getObjList(category)[index]);
		}
		
		public int getObjCount(OBJECT_CATEGORY category)
		{
			return getObjList(category).Count;
		}

		/// <summary>
		/// Replaces a Block
		/// </summary>
		public void updateBlock(int index, Block newBlock)
		{
			Block oldBlock = blocks[index];
			blocks[index] = newBlock;
			historyStack.Add(new HNodeBlockUpdated(this, oldBlock, newBlock, index));
		}

		/// <summary>
		/// Returns a copy
		/// </summary>
		public Block getBlock(int index)
		{
			return blocks[index];
		}

		/// <summary>
		/// Replaces a Collision
		/// </summary>
		public void updateColl(int index, Collision newColl)
		{
			Collision oldColl = collisions[index];
			collisions[index] = newColl;
			historyStack.Add(new HNodeCollUpdated(this, oldColl, newColl, index));
		}

		/// <summary>
		/// Returns a copy
		/// </summary>
		public Collision getColl(int index)
		{
			return collisions[index];
		}

		/// <summary>
		/// Replaces a Decoration
		/// </summary>
		public void updateDeco(DECO_CATEGORY category, int index, Decoration newDeco)
		{
			List<Decoration> l = getDecoList(category);
			Decoration oldDeco = l[index];
			l[index] = newDeco;
			historyStack.Add(new HNodeDecoUpdated(this, oldDeco, newDeco, index, category));
		}

		/// <summary>
		/// Returns a copy
		/// </summary>
		public Decoration getDeco(DECO_CATEGORY category, int index)
		{
			return getDecoList(category)[index];
		}

		/// <summary>
		/// Replaces StageData
		/// </summary>
		public void updateLevelProperties(LevelProperties newData)
		{
			LevelProperties oldData = levelProperties;
			levelProperties = newData;
			historyStack.Add(new HNodeLevelPropertiesUpdated(this, oldData, newData));
		}

		/// <summary>
		/// Returns a copy
		/// </summary>
		public LevelProperties getLevelProperties()
		{
			return levelProperties;
		}

		private List<LevelObject> getObjList(OBJECT_CATEGORY t)
		{
			switch (t)
			{
				case OBJECT_CATEGORY.GENERIC:
					return objects;
				case OBJECT_CATEGORY.ITEMS:
					return items;
				case OBJECT_CATEGORY.GS_ITEM:
					return gsItems;
				case OBJECT_CATEGORY.BOSS:
					return bosses;
				case OBJECT_CATEGORY.ENEMY:
					return enemies;
			}
			//Ooof???
			return objects;
		}

		private List<Decoration> getDecoList(DECO_CATEGORY t)
		{
			switch (t)
			{
				case DECO_CATEGORY.GENERIC:
					return decos;
				case DECO_CATEGORY.BACK:
					return decosBack;
				case DECO_CATEGORY.FRONT:
					return decosFront;
				case DECO_CATEGORY.UNK:
					return decosUnk;
			}
			//Ooof???
			return decos;
		}

		public string getObjCString(OBJECT_CATEGORY t)
		{
			switch (t)
			{
				case OBJECT_CATEGORY.GENERIC:
					return "Object";
				case OBJECT_CATEGORY.ITEMS:
					return "Item";
				case OBJECT_CATEGORY.GS_ITEM:
					return "GuestStarItem";
				case OBJECT_CATEGORY.BOSS:
					return "Boss";
				case OBJECT_CATEGORY.ENEMY:
					return "Enemy";
			}
			return "Object";
		}

		public string getDecoCString(DECO_CATEGORY t)
		{
			switch (t)
			{
				case DECO_CATEGORY.GENERIC:
					return "Decoration";
				case DECO_CATEGORY.BACK:
					return "BackDecoration";
				case DECO_CATEGORY.FRONT:
					return "FrontDecoration";
				case DECO_CATEGORY.UNK:
					return "UnknownDecoration";
			}
			return "Decoration";
		}

		private abstract class HistoryNode
		{
			protected LevelSession parent;
			private bool undone = false;

			protected HistoryNode(LevelSession parent)
			{
				this.parent = parent;
			}
			protected abstract void doUndo();
			protected abstract void doRedo();
			public void undo()
			{
				if (!undone) { doUndo(); undone = true; }
			}
			public void redo()
			{
				if (undone) { doRedo(); undone = false; }
			}
			public bool isUndone()
			{
				return undone;
			}
		}

		private class HNodeObjRemoved : HistoryNode
		{

			protected LevelObject removedObj;
			protected int index;
			protected OBJECT_CATEGORY list;

			public HNodeObjRemoved(LevelSession parent, LevelObject removedObj, int index, OBJECT_CATEGORY list)
				: base(parent)
			{
				this.removedObj = new LevelObject(removedObj);
				this.index = index;
				this.list = list;
			}

			protected override void doRedo()
			{
				List<LevelObject> targetList = parent.getObjList(list);
				targetList.RemoveAt(index);
			}

			protected override void doUndo()
			{
				List<LevelObject> targetList = parent.getObjList(list);
				targetList.Insert(index, new LevelObject(removedObj));
			}
		}

		private class HNodeObjAdded : HistoryNode
		{

			protected LevelObject addedObj;
			protected int index;
			protected OBJECT_CATEGORY list;

			public HNodeObjAdded(LevelSession parent, LevelObject addedObj, int index, OBJECT_CATEGORY list)
				: base(parent)
			{
				this.addedObj = new LevelObject(addedObj);
				this.index = index;
				this.list = list;
			}

			protected override void doRedo()
			{
				List<LevelObject> targetList = parent.getObjList(list);
				targetList.Insert(index, new LevelObject(addedObj));
			}

			protected override void doUndo()
			{
				List<LevelObject> targetList = parent.getObjList(list);
				targetList.RemoveAt(index);
			}
		}

		private class HNodeObjUpdated : HistoryNode
		{

			protected LevelObject oldObj, newObj;
			protected int index;
			protected OBJECT_CATEGORY list;

			public HNodeObjUpdated(LevelSession parent, LevelObject oldObject, LevelObject newObject, int index, OBJECT_CATEGORY list)
				: base(parent)
			{
				this.oldObj = new LevelObject(oldObject);
				this.newObj = new LevelObject(newObject);
				this.index = index;
				this.list = list;
			}

			protected override void doRedo()
			{
				List<LevelObject> targetList = parent.getObjList(list);
				targetList[index] = new LevelObject(newObj);
			}

			protected override void doUndo()
			{
				List<LevelObject> targetList = parent.getObjList(list);
				targetList[index] = new LevelObject(oldObj);
			}
		}

		private class HNodeCollUpdated : HistoryNode
		{

			protected Collision oldColl, newColl;
			protected int index;

			public HNodeCollUpdated(LevelSession parent, Collision oldCollision, Collision newCollision, int index)
				: base(parent)
			{
				this.oldColl = oldCollision;
				this.newColl = newCollision;
				this.index = index;
			}

			protected override void doRedo()
			{
				parent.collisions[index] = newColl;
			}

			protected override void doUndo()
			{
				parent.collisions[index] = oldColl;
			}
		}

		private class HNodeBlockUpdated : HistoryNode
		{

			protected Block oldBlock, newBlock;
			protected int index;

			public HNodeBlockUpdated(LevelSession parent, Block oldBlock, Block newBlock, int index)
				: base(parent)
			{
				this.oldBlock = oldBlock;
				this.newBlock = newBlock;
				this.index = index;
			}

			protected override void doRedo()
			{
				parent.blocks[index] = newBlock;
			}

			protected override void doUndo()
			{
				parent.blocks[index] = oldBlock;
			}
		}

		private class HNodeDecoUpdated : HistoryNode
		{

			protected Decoration oldDeco, newDeco;
			protected DECO_CATEGORY list;
			protected int index;

			public HNodeDecoUpdated(LevelSession parent, Decoration oldDeco, Decoration newDeco, int index, DECO_CATEGORY list)
				: base(parent)
			{
				this.oldDeco = oldDeco;
				this.newDeco = newDeco;
				this.index = index;
				this.list = list;
			}

			protected override void doRedo()
			{
				parent.getDecoList(list)[index] = newDeco;
			}

			protected override void doUndo()
			{
				parent.getDecoList(list)[index] = oldDeco;
			}
		}

		private class HNodeLevelPropertiesUpdated : HistoryNode
		{

			protected LevelProperties oldProperties, newProperties;

			public HNodeLevelPropertiesUpdated(LevelSession parent, LevelProperties oldProperties, LevelProperties newProperties)
				: base(parent)
			{
				this.oldProperties = oldProperties;
				this.newProperties = newProperties;
			}

			protected override void doRedo()
			{
				parent.levelProperties = newProperties;
			}

			protected override void doUndo()
			{
				parent.levelProperties = oldProperties;
			}
		}

	}

}
