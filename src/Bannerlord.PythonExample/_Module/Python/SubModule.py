class SubModule(object):
  def __init__(self, base):
    self.base = base

  def OnSubModuleLoad(self):
      self.base.SubModuleLoad();
      return;

  def OnSubModuleUnloaded(self):
      self.base.SubModuleUnloaded();
      return;

  def OnBeforeInitialModuleScreenSetAsRoot(self):
      self.base.BeforeInitialModuleScreenSetAsRoot();
      return;