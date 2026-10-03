Alter procedure SP_UpdateEmployeeContract
(
	@EmployeeContractId int,
	@StartDate date,
	@EndDate date,
	@ShiftId int,
	@Salary float,
	@WorkingHours float,
	@Monday bit,
	@Tuesday bit,
	@Wednesday bit,
	@Thursday bit,
	@Friday bit,
	@Saturday bit,
	@Sunday bit,
	@AssignedBuildingId int
) 
as 
begin try 
	begin transaction
		
		if exists (select 1 from WorkingDays where EmployeeId = (select EmployeeId from EmployeesContracts where EmployeeContractId = @EmployeeContractId))
		begin 
			update WorkingDays
			set Monday = @Monday,
				Tuesday = @Tuesday,
				Wednesday = @Wednesday,
				Thursday = @Thursday,
				Friday = @Friday,
				Saturday = @Saturday,
				Sunday = @Sunday
			where EmployeeId = (select EmployeeId from EmployeesContracts where EmployeeContractId = @EmployeeContractId)
		End
		else
		begin
			declare @WorkingDaysId int;
			insert into WorkingDays (EmployeeId, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday)
			values ((select EmployeeId from EmployeesContracts where EmployeeContractId = @EmployeeContractId), @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Saturday, @Sunday)

			set @WorkingDaysId = SCOPE_IDENTITY()
        end

		update EmployeesContracts
		set StartDate = @StartDate,
			EndDate = @EndDate,
			ShiftId = @ShiftId,
			Salary = @Salary,
			WorkingHours = @WorkingHours,
			WorkingDays = ISNULL((select WorkingDaysId from WorkingDays where EmployeeId = (select EmployeeId from EmployeesContracts where EmployeeContractId = @EmployeeContractId)), @WorkingDaysId),
			AssignedBuildingId = @AssignedBuildingId
		where EmployeeContractId = @EmployeeContractId
		commit transaction
		
	end try
begin catch
		if @@trancount > 0
			rollback transaction
		declare @ErrorMessage nvarchar(4000), @ErrorSeverity int, @ErrorState int
		select @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE()
		raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)
end catch
