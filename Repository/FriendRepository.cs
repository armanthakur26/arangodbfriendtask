using ArangoDB.Client;
using Arangodbtest.model;
using Arangodbtest.Repository.Irepository;

namespace Arangodbtest.Repository
{
    public class FriendRepository : IFriendrepostory
    {

        private readonly IArangoDatabase _arangodatabase;
        private readonly string _collectionName;
        public FriendRepository(IArangoDatabase arangoDatabase)
        {
            _arangodatabase = arangoDatabase;
            _collectionName = "Friends";
        }

        public void addFriendRelation(Friends friend)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            collection.Insert(friend);
        }

        public void deleteRelation(string _key)
        {
           var collection=_arangodatabase.Collection(_collectionName);
            var del=collection.Document<Friends>(_key);
            collection.Remove(del);
        }

        public ICollection<Friends> GetFriendRelation()
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var Friend = collection.All<Friends>().ToList();
            return Friend;
        }

        public void updateRelation(Friends friend)
        {
            var collection=_arangodatabase.Collection(_collectionName);
            var friendrelation = collection.Document<Friends>(friend._key);
            if (friend != null)
            {
                friend._from=friendrelation._from;
                friend._to = friendrelation._to;
            }
            collection.Update(friendrelation);
        }
    }
}
