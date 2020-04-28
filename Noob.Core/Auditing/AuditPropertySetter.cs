using Noob.DependencyInjection;
using Noob.Users;

namespace Noob.Auditing
{
    public class AuditPropertySetter : IAuditPropertySetter, ITransientDependency
    {
        protected ICurrentUser CurrentUser { get; }

        public AuditPropertySetter(ICurrentUser currentUser)
        {
            CurrentUser = currentUser;
        }

        public void SetCreationProperties(object targetObject)
        {
            SetCreationTime(targetObject);
            SetCreatorId(targetObject);
        }

        public void SetModificationProperties(object targetObject)
        {
            SetLastModificationTime(targetObject);
            SetLastModifierId(targetObject);
        }

        public void SetDeletionProperties(object targetObject)
        {
            SetDeletionTime(targetObject);
            SetDeleterId(targetObject);
        }

        private void SetCreationTime(object targetObject)
        {
            if (!(targetObject is IHasCreationTime objectWithCreationTime))
            {
                return;
            }

            if (objectWithCreationTime.CreationTime == default)
            {
                objectWithCreationTime.CreationTime = System.DateTime.Now;
            }
        }

        private void SetCreatorId(object targetObject)
        {
            if (!CurrentUser.Id.HasValue)
            {
                return;
            }
            if (targetObject is IMayHaveCreator mayHaveCreatorObject)
            {
                if (mayHaveCreatorObject.CreatorId.HasValue && mayHaveCreatorObject.CreatorId.Value != default)
                {
                    return;
                }

                mayHaveCreatorObject.CreatorId = CurrentUser.Id;
            }
            else if (targetObject is IMustHaveCreator mustHaveCreatorObject)
            {
                if (mustHaveCreatorObject.CreatorId != default)
                {
                    return;
                }

                mustHaveCreatorObject.CreatorId = CurrentUser.Id.Value;
            }
        }

        private void SetLastModificationTime(object targetObject)
        {
            if (targetObject is IHasModificationTime objectWithModificationTime)
            {
                objectWithModificationTime.LastModificationTime = System.DateTime.Now;
            }
        }

        private void SetLastModifierId(object targetObject)
        {
            if (!(targetObject is IModificationAuditedObject modificationAuditedObject))
            {
                return;
            }

            if (!CurrentUser.Id.HasValue)
            {
                modificationAuditedObject.LastModifierId = null;
                return;
            }
            modificationAuditedObject.LastModifierId = CurrentUser.Id;
        }

        private void SetDeletionTime(object targetObject)
        {
            if (targetObject is IHasDeletionTime objectWithDeletionTime)
            {
                if (objectWithDeletionTime.DeletionTime == null)
                {
                    objectWithDeletionTime.DeletionTime = System.DateTime.Now;
                }
            }
        }

        private void SetDeleterId(object targetObject)
        {
            if (!(targetObject is IDeletionAuditedObject deletionAuditedObject))
            {
                return;
            }

            if (deletionAuditedObject.DeleterId != null)
            {
                return;
            }

            if (!CurrentUser.Id.HasValue)
            {
                deletionAuditedObject.DeleterId = null;
                return;
            }
            deletionAuditedObject.DeleterId = CurrentUser.Id;
        }
    }
}
