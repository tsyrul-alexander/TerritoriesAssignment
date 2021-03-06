﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLiteFramework.Condition;
using SQLiteFramework.Condition.Value;

namespace SQLiteFramework.Command {
	public class SQLiteDeleteCommand : SQLiteBaseTableOperationCommand {
		private const string DeleteCommandName = "DELETE";
		public SQLiteDeleteCommand(string tableName, IEnumerable<ISQLiteCondition> conditions) : base(tableName,
			conditions) { }
		public override string GetCommandSql() {
			return $"{DeleteCommandName} {FromCommandName} {TableName} {GetConditionsSql()}";
		}
	}
}
