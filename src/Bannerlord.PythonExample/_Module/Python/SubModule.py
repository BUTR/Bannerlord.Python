import clr
clr.AddReference("TaleWorlds.Library")

from TaleWorlds.Library import InformationMessage
from TaleWorlds.Library import InformationManager

class SubModule(object):
    def __init__(self, base):
        self.base = base

    def OnSubModuleLoad(self):
        self.base.OnSubModuleLoad()
        return

    def OnSubModuleUnloaded(self):
        self.base.OnSubModuleUnloaded()
        return

    def OnBeforeInitialModuleScreenSetAsRoot(self):
        self.base.OnBeforeInitialModuleScreenSetAsRoot()

        message = InformationMessage("test")
        InformationManager.DisplayMessage(message)
        return
