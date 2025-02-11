using Expense.Service;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        //private const char V = 'test';

        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            Project project = new (ProjectType.INTERNAL, "internalTest");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project project = new (ProjectType.EXTERNAL, "Project A");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project project = new (ProjectType.EXTERNAL, "Project B");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            Project project = new (ProjectType.EXTERNAL, "Project Unexpected");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            Project project = new (ProjectType.UNEXPECTED_PROJECT_TYPE, "Project Unexpected");
            // when
            // then
            Assert.Throws<UnexpectedProjectTypeException>(
                () => ExpenseService.GetExpenseCodeByProjectTypeAndName(project));
        }
    }
}