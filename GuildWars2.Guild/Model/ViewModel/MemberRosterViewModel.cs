﻿using GuildWars2API.Model.Guild;
using GuildWars2Guild.Model.ViewModel.Bases;
using System.Collections.Generic;
using System.Windows.Data;
using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.Resources;

namespace GuildWars2Guild.Model.ViewModel
{
    class MemberRosterViewModel : BaseViewModel
    {
        public List<OrderEntry> MainCollection { get; set; }

        public MemberRosterViewModel() {
            var guildDetails = ResourceManager.Instance.GetResource<GuildDetails>(Properties.Settings.Default.GuildName);
            var members = GuildWars2API.GuildAPI.GetMembersByID(guildDetails?.GuildID, Properties.Settings.Default.ApiKey);
            if(members != null) {
                MainCollection = ConvertMembers(members);
                MainCollectionView = CollectionViewSource.GetDefaultView(MainCollection);
            }
        }

        private List<OrderEntry> ConvertMembers(List<Member> members) {
            var memberEntries = new List<OrderEntry>();
            foreach(Member member in members) {
                memberEntries.Add(Reflection.CopyClass<OrderEntry, Member>(member));
            }
            return memberEntries;
        }
    }
}