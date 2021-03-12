using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Updater {
    readonly HashSet<IOnUpdate> hash_updates = new HashSet<IOnUpdate>();
    readonly List<IOnUpdate> list_updates_to_remove = new List<IOnUpdate>(20);
    readonly List<IOnUpdate> list_updates_to_queue = new List<IOnUpdate>(20);

    bool isUpdating = false;
    public void Update() {
        //Debug.Log(hash_updates.Count);
        isUpdating = true;
        foreach (var updater in hash_updates) {
            updater.TimeSinceUpdating += Time.smoothDeltaTime;
            if (updater.RemoveThisFromUpdater) {
                list_updates_to_remove.Add(updater);
            }
            else {
                updater.OnUpdate();
            }
        }
        isUpdating = false;

        foreach(var update in list_updates_to_queue) {
            AddToUpdate(update);
        }
        list_updates_to_queue.Clear();

        for (int i = list_updates_to_remove.Count - 1; i > -1; i--) {
            var updater = list_updates_to_remove[i];
            if (updater.RemoveThisFromUpdater) {
                RemoveFromUpdate(updater);
                list_updates_to_remove.RemoveAt(i);
            }
        }
        Debug.Assert(list_updates_to_remove.Count == 0);
    }

    public void AddToUpdate(IOnUpdate update) {
        if (!hash_updates.Contains(update)) {
            if (isUpdating) {
                Debug.LogWarning($"Atempting to modify updater collection! {update}");
                list_updates_to_queue.Add(update);
                return;
            }
            hash_updates.Add(update);
            update.RemoveThisFromUpdater = false;
            update.TimeSinceUpdating = 0;
        }
        else {
            Debug.LogWarning($"Atempting to add duplicate {update} to updater.");
        }
    }

    void RemoveFromUpdate(IOnUpdate update) {
        if (!hash_updates.Contains(update)) {
            Debug.LogWarning("tried to remove update that was not in the set.");
            return;
        }
        hash_updates.Remove(update);
        update.RemoveThisFromUpdater = false;
    }
}