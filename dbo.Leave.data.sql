SET IDENTITY_INSERT [dbo].[Leave] ON
INSERT INTO [dbo].[Leave] ([LeaveId], [reason], [status], [phone], [Email], [Start Date], [End Date], [categories], [Employeename])
VALUES 
    (3, 'Maternity Leave', 'Pending', 5555555555, 'janedoe@example.com', '2023-04-01', '2023-06-30', 'Maternity Leave', 'tobi'),
    (4, 'Personal Leave', 'Approved', 1111111111, 'johndoe@example.com', '2023-04-15', '2023-04-16', 'Personal Leave', 'tobi'),
    (5, 'Vacation', 'Pending', 2222222222, 'janedoe@example.com', '2023-05-01', '2023-05-05', 'Paid Leave', 'tobi'),
    (6, 'Sick Leave', 'Approved', 3333333333, 'johndoe@example.com', '2023-05-15', '2023-05-16', 'Sick Leave', 'tobi'),
    (7, 'Personal Leave', 'Denied', 4444444444, 'janedoe@example.com', '2023-06-01', '2023-06-02', 'Personal Leave', 'tobi')
