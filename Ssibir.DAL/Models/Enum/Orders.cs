using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssibir.DAL.Models.Enums
{
	public enum ClientOrder
	{
		Name=0,
		Birth,
		LastTripDate,
	}
	public enum DocOrder
	{
		Name = 0,
		Birth,
		ExpirationDate,
	}
	public enum HotelOrder
	{
		Name = 0,
		Address,
		Stars,
	}
	public enum ManagerOrder
	{
		Name = 0,
		Birth,
		ClientsCount,
	}
	public enum TourOrder
	{
		Title = 0,
		Hotel,
		Operator,
		Cost,
		Type,
	}
	public enum TripOrder
	{
		Nr = 0,
		ClientName,
		ManagerName,
		Cost,
		Status,
	}
	public enum DirectionOrder
	{
		Title = 0
	}
	public enum OperatorOrder
	{
		Title = 0
	}
	public enum CommentOrder
	{
		Substring =0
	}
}
