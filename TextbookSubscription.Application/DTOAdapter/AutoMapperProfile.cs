namespace TextbookSubscription.Application.DTOAdapter
{
    using AutoMapper;
    using TextbookSubscription.ViewModels;
    using TextbookSubscription.Domain.Entity;

    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// 配置映射关系
        /// </summary>
        protected override void Configure()
        {
            // Term => TermView
            CreateMap<Term, TermView>()
                .ForMember(tv => tv.TermID, opt => opt.MapFrom(t => t.TermNum))
                .ForMember(tv => tv.Term, opt => opt.MapFrom(tv => tv.TermName));

            // School => SchoolView
            CreateMap<School, SchoolView>();

            // SchoolView => School
            CreateMap<SchoolView, School>();

            // Department => DepartmentView
            CreateMap<Department, DepartmentView>();

            // Declaration => StudentDeclaration/TeacherDeclaration
            // 仅在导入申报时为了消除重复代码用
            CreateMap<Declaration, StudentDeclaration>();
            CreateMap<Declaration, TeacherDeclaration>();
        }
    }
}
