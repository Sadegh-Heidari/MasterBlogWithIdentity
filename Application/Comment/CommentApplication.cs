using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Comment;
using ApplicationServices.Comment.DTO;
using DomainServices.UnitOfWork;

namespace Application.Comment
{
    public class CommentApplication:ICommentApplication
    {
        private IUnitOfWork unitOfWork { get; }

        public CommentApplication(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
           
        }

        public List<CommentListDTO> GetAllComments()
        {
            var result = unitOfWork.CommentRepository.GetComment<CommentListDTO>();
            return result;
        }

        public void Confirm(string Id)
        {
            var comment = getComment(Id);
            comment!.Confirm();
            UpdateAndSave(comment);
        }

        public void Cancel(string Id)
        {
            var comment = getComment(Id);
            comment!.Cancel();
            UpdateAndSave(comment);
        }

        private Domain.CommentAgg.Comment? getComment(string id)
        {
            return unitOfWork.CommentRepository.GetComment(id);
        }
        private void UpdateAndSave(Domain.CommentAgg.Comment comment)
        {
            unitOfWork.CommentRepository.Update(comment);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
