using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ClubCompetition.Models;

namespace ClubCompetition.ViewModels
{
    public class CompetitionViewModel
    {
        public Competition Competition { get; set; }

        [Display(Name = "Members")]
        public IEnumerable<SelectListItem> AllMembers { get; set; }

        private List<int> _selectedMembers;
        public List<int> SelectedMembers
        {
            get
            {
                if (_selectedMembers == null)
                {
                    _selectedMembers = Competition.Members.Select(m => m.MemberId).ToList();
                }
                return _selectedMembers;
            }
            set { _selectedMembers = value; }
        }
    }
}