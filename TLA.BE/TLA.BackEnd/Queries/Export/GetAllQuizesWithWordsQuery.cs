using MediatR;
using TLA.BackEnd.QueryHandlersResponses;

namespace TLA.BackEnd.Queries.Export
{
    public class GetAllQuizesWithWordsQuery : IRequest<AllQuizesWithWordsQueryResponse>
    {

    }
}
