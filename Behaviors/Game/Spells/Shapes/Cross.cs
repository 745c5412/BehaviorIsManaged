#region License GNU GPL
// Cross.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using System.Collections.Generic;
using System.Linq;
using BiM.Behaviors.Game.World;
using BiM.Protocol.Enums;

namespace BiM.Behaviors.Game.Spells.Shapes
{
    public class Cross : IShape
    {
        public Cross(byte minRadius, byte radius, DirectionsEnum? direction = null)
        {
            MinRadius = minRadius;
            Radius = radius;

            DisabledDirections = new List<DirectionsEnum>();
            if (direction != null) Direction = direction.Value;
        }

        public bool Diagonal
        {
            get;
            set;
        }

        public List<DirectionsEnum> DisabledDirections
        {
            get;
            set;
        }

        public bool OnlyPerpendicular
        {
            get;
            set;
        }

        public bool AllDirections
        {
            get;
            set;
        }

        #region IShape Members

        public uint Surface
        {
            get
            {
                return (uint)Radius * 4 + 1;
            }
        }

        public byte MinRadius
        {
            get;
            set;
        }

        public DirectionsEnum Direction
        {
            get;
            set;
        }

        public byte Radius
        {
            get;
            set;
        }

        public Cell[] GetCells(Cell centerCell, Map map)
        {
            var result = new List<Cell>();

            if (MinRadius == 0)
                result.Add(centerCell);

            List<DirectionsEnum> disabledDirections = DisabledDirections.ToList();
            if (OnlyPerpendicular)
            {
                switch (Direction)
                {
                    case DirectionsEnum.DIRECTION_SOUTH_EAST:
                    case DirectionsEnum.DIRECTION_NORTH_WEST:
                        {
                            disabledDirections.Add(DirectionsEnum.DIRECTION_SOUTH_EAST);
                            disabledDirections.Add(DirectionsEnum.DIRECTION_NORTH_WEST);
                            break;
                        }
                    case DirectionsEnum.DIRECTION_NORTH_EAST:
                    case DirectionsEnum.DIRECTION_SOUTH_WEST:
                        {
                            disabledDirections.Add(DirectionsEnum.DIRECTION_NORTH_EAST);
                            disabledDirections.Add(DirectionsEnum.DIRECTION_SOUTH_WEST);
                            break;
                        }
                    case DirectionsEnum.DIRECTION_SOUTH:
                    case DirectionsEnum.DIRECTION_NORTH:
                        {
                            disabledDirections.Add(DirectionsEnum.DIRECTION_SOUTH);
                            disabledDirections.Add(DirectionsEnum.DIRECTION_NORTH);
                            break;
                        }
                    case DirectionsEnum.DIRECTION_EAST:
                    case DirectionsEnum.DIRECTION_WEST:
                        {
                            disabledDirections.Add(DirectionsEnum.DIRECTION_EAST);
                            disabledDirections.Add(DirectionsEnum.DIRECTION_WEST);
                            break;
                        }
                }
            }

            for (var i = (int)Radius; i > 0; i--)
            {
                if (i < MinRadius)
                    continue;

                if (!Diagonal)
                {
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_SOUTH_EAST))
                        AddCellIfValid(centerCell.X + i, centerCell.Y, map, result);
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_NORTH_WEST))
                        AddCellIfValid(centerCell.X - i, centerCell.Y, map, result);
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_NORTH_EAST))
                        AddCellIfValid(centerCell.X, centerCell.Y + i, map, result);
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_SOUTH_WEST))
                        AddCellIfValid(centerCell.X, centerCell.Y - i, map, result);
                }

                if (Diagonal || AllDirections)
                {
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_SOUTH))
                        AddCellIfValid(centerCell.X + i, centerCell.Y - i, map, result);
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_NORTH))
                        AddCellIfValid(centerCell.X - i, centerCell.Y + i, map, result);
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_EAST))
                        AddCellIfValid(centerCell.X + i, centerCell.Y + i, map, result);
                    if (!disabledDirections.Contains(DirectionsEnum.DIRECTION_WEST))
                        AddCellIfValid(centerCell.X - i, centerCell.Y - i, map, result);
                }
            }

            return result.ToArray();
        }
        private static void AddCellIfValid(int x, int y, Map map, IList<Cell> container)
        {
            if (!Cell.IsInMap(x, y))
                return;

            container.Add(map.Cells[x, y]);
        }
        #endregion
    }
}